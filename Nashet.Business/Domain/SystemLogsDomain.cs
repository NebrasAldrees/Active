using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class SystemLogsDomain(SystemLogsRepository Repository) : BaseDomain 
    {

        public async Task<int> InsertLog(SystemLogsViewModel viewModel)
        {
            try
            {
                tblSystemLogs Log =new tblSystemLogs
                {
                    LogsId = viewModel.LogsId,
                    UserId = viewModel.UserId,
                    username = viewModel.username,
                    Table = viewModel.Table,
                    operation_type = viewModel.operation_type,
                    operation_date = viewModel.operation_date,
                    OldValue = viewModel.OldValue,
                    NewValue = viewModel.NewValue,
                    other_details = viewModel.other_details

                };
                int check = await _SystemLogsRepository .InsertLog(Log);
                if (check == 0)
                    return 0;
                else
                    return 1;
            }
            catch
            {
                return 0;
            }
        }




    }
}
