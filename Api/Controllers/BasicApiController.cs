﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BasicApiController
    {
        [Route("/api/[controller]")]
        [ApiController]
        public class BaseApiController : ControllerBase
        {
        }
    }
}
