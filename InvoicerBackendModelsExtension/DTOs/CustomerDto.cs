﻿using InvoicerBackendModelsExtension.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.DTOs;

public record PlatformCustomerDto(string CustomerName,string CustomerAddress,
    string CustomerLegacyId,PlatformCustomerType CustomerRank, Guid CustomerId);
