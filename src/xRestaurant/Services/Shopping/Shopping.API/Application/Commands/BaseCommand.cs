using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Commands;

namespace Shopping.API.Application.Commands
{
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// The Aggregate ID of the Aggregate Root being changed
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Expected Version which the Aggregate will become.
        /// </summary>
        public int ExpectedVersion { get; set; }
    }
}
