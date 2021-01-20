using APIExample.Models;
using PagedList;

namespace APIExample
{
    public class BusinessViewModel : BasePagedListModel<Business>
    {
        private string cnpj;
        public string CNPJ
        {
            get => cnpj;
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                cnpj = value;
                AppendFilter(x => x.CNPJ == CNPJ);
            }
        }
    }
}
