using AutoMapper;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Domain.Entities;
using ClosedXML.Excel;
using VechileManagement.Application.Features.VechileModel.DTOs;
using System.Linq;
using VechileManagement.Domain.Enums;

namespace VechileManagement.Application.Features.VechileModel.Handlers.Commands
{
    public class UploadExcelDataCommandHandler : IRequestHandler<UploadExcelDataCommand, UploadExcelDataResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UploadExcelDataCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UploadExcelDataResponse> Handle(UploadExcelDataCommand request, CancellationToken cancellationToken)
        {
            var response = new UploadExcelDataResponse();

            try
            {
                using (var stream = new MemoryStream())
                {
                    await request.File.CopyToAsync(stream);
                    stream.Position = 0;

                    using (var workbook = new XLWorkbook(stream))
                    {
                        var worksheet = workbook.Worksheet(1);
                        var rows = worksheet.RowsUsed();

                        foreach (var row in rows.Skip(1)) // Skip header row
                        {
                            string model;
                            decimal width;
                            decimal length;
                            decimal height;
                            int axleDistance;
                            int numberOfAxle;
                            int engineCapacity;
                            int numberOfCylinder;
                            int horsePower;
                            int numberOfTyreF;
                            int numberOfTyreB;
                            int grossWeight;
                            int netWeight;
                            int numberOfSeat;
                            int cargoCapacity;
                            decimal tyreSizeF;
                            decimal tyreSizeB;
                            string typeOfDrive;
                            Guid factoryId;
                            FuelType fuelType;


                            // Check if the cell values can be converted to decimal
                            if (decimal.TryParse(row.Cell(2).Value.ToString(), out width) &&
                                decimal.TryParse(row.Cell(3).Value.ToString(), out length) &&
                                decimal.TryParse(row.Cell(4).Value.ToString(), out height))
                            {
                                var vehicleModelDto = new CreateVechileModelDto
                                {
                                   // Model = model,
                                    Width = width,
                                    Length = length,
                                    Height = height,
                                   // NumberOfAxle = numberOfAxle,
                                   // AxleDistance = axleDistance,
                                };

                                var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelDto);
                                await _unitOfWork.VechileModelRepository.AddAsync(vehicleModel);
                            }
                            else
                            {
                                // Handle the case where conversion fails
                                // Log an error, skip the row, or take appropriate action
                            }
                        }

                        await _unitOfWork.Save();
                        response.Success = true;
                        response.Message = "Excel data uploaded successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while processing the Excel file.";
                // Log or handle the exception
            }

            return response;
        }
    }
}
