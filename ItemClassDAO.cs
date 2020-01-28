using BCErp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BCErp.DataAccess
{
   public class ItemClassDAO
    
    {
            public List<ItemClassDTO> GetAll()
            {
                List<ItemClassDTO> itemClassDTOs = new List<ItemClassDTO>();

                SqlCommand cmd = new SqlCommand("select * from Inventory.TblItemClass", DbConnector.Connect());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                DataTable dt = dataSet.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   ItemClassDTO itemClassDTO = new ItemClassDTO()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                        Code = Convert.ToString(dt.Rows[i]["Code"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]),
                        CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]),
                        Active = Convert.ToBoolean(dt.Rows[i]["Active"])
                    };

                    if (dt.Rows[i]["ModifiedOn"] != DBNull.Value)
                        itemClassDTO.ModifiedOn = Convert.ToDateTime(dt.Rows[i]["ModifiedOn"]);
                    if (dt.Rows[i]["ModifiedBy"] != DBNull.Value)
                        itemClassDTO.ModifiedBy = Convert.ToInt32(dt.Rows[i]["ModifiedBy"]);

                    itemClassDTOs.Add(itemClassDTO);
                }

                return itemClassDTOs;
            }

            public ItemClassDTO GetById(int id)
            {
            ItemClassDTO itemClassDTO = new ItemClassDTO();

                SqlCommand cmd = new SqlCommand("select * from Inventory.TblItemClass where Id=@Id", DbConnector.Connect());
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                DataTable dt = dataSet.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    itemClassDTO = new ItemClassDTO()
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                        Code = Convert.ToString(dt.Rows[0]["Code"]),
                        Name = Convert.ToString(dt.Rows[0]["Name"]),
                        CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]),
                        CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]),
                        Active = Convert.ToBoolean(dt.Rows[0]["Active"])
                    };

                    if (dt.Rows[0]["ModifiedOn"] != DBNull.Value)
                        itemClassDTO.ModifiedOn = Convert.ToDateTime(dt.Rows[0]["ModifiedOn"]);
                    if (dt.Rows[0]["ModifiedBy"] != DBNull.Value)
                        itemClassDTO.ModifiedBy = Convert.ToInt32(dt.Rows[0]["ModifiedBy"]);


                }

                return itemClassDTO;
            }

            public int Create(ItemClassDTO itemClassDTO)
            {
                SqlCommand cmd = new SqlCommand("SpCreateItemClass", DbConnector.Connect());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Code", itemClassDTO.Code);
                cmd.Parameters.AddWithValue("@Name", itemClassDTO.Name);
                cmd.Parameters.AddWithValue("@CreatedBy", itemClassDTO.CreatedBy);
                cmd.Parameters.AddWithValue("@Active", itemClassDTO.Active);

                return cmd.ExecuteNonQuery();

            }

            public int Edit(ItemClassDTO itemClassDTO)
            {
                SqlCommand cmd = new SqlCommand("SpEditItemClass", DbConnector.Connect());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", itemClassDTO.Id);
                cmd.Parameters.AddWithValue("@Code", itemClassDTO.Code);
                cmd.Parameters.AddWithValue("@Name", itemClassDTO.Name);
                cmd.Parameters.AddWithValue("@ModifiedBy", itemClassDTO.ModifiedBy);
                cmd.Parameters.AddWithValue("@Active", itemClassDTO.Active);

                return cmd.ExecuteNonQuery();

            }
        }
    }
