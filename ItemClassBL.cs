using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCErp.DataAccess;
using BCErp.DTO;


namespace BCErp.BusinessLogic
{
    public class ItemClassBL
    {
        ItemClassDAO itemClassDAO = new ItemClassDAO();

        public List<ItemClassDTO> GetAll()
        {
            return itemClassDAO.GetAll();
        }

        public int Create(ItemClassDTO itemClassDTO)
        {
            return itemClassDAO.Create(itemClassDTO);
        }

        public int Edit(ItemClassDTO itemClassDTO)
        {
            return itemClassDAO.Edit(itemClassDTO);
        }
        public ItemClassDTO GetById(int id)
        {
            return itemClassDAO.GetById(id);
        }
    }
}
