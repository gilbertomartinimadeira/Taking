﻿using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public IEnumerable<SaleItemDTO> Items { get; set; } = [];
    }
}
