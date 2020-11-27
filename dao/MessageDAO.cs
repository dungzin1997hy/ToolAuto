using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ToolTest.dao
{
    class MessageDAO
    {
        public static String FBsql = "and Time(time)>Time(date_sub(now(),INTERVAL 60 second)) and Date(time) = Date(now())";
        public static String  getCode(String sim_id,String sql)
        {
            String code = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                 code =getMessage(conn,sim_id,sql);
                if (code.Equals("") == false)
                    Console.WriteLine(code);
                else
                    Console.WriteLine("ko co code");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Đóng kết nối.
                conn.Close();
                // Tiêu hủy đối tượng, giải phóng tài nguyên.
                conn.Dispose();
            }



            return code;
        }
        public static String getStatus (String deviceID)

        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String status = "";
            try
            {
                String sql = "SELECT status FROM device_status WHERE device_id = '" + deviceID + "' ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand();

                // Liên hợp Command với Connection.
                cmd.Connection = conn;
                cmd.CommandText = sql;


                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            status = reader.GetString(0);
                        }
                    }

                }
            }catch(Exception e)
            {
                
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return status;

        }
        public static String getMessage(MySqlConnection conn,String simID, String sql)
        {
            String code = "";
            String a = " ";
            String sql1 = "SELECT * FROM messages where sim_id = '" + simID + "' and sdt ='FACEBOOK' "+sql+" order by id desc limit 1;";
            // Tạo một đối tượng Command.
            MySqlCommand cmd = new MySqlCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql1;

            String content = "";
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                      
                        content = reader.GetString(1);
                       
                        String[] arr = content.Split(" ");

                        for(int i = 0; i < arr.Length; i++)
                        {
                   
                            try
                            {
                                code = Int32.Parse(arr[i])+"";
                                Console.WriteLine("Message: " + content);
                                return code;
                            }
                            catch(Exception e)
                            {
                              
                                continue;
                            }
                        }

                    
                    }
                }

        
            }
            Console.WriteLine("Message: " + content);
            return code;
        }
    }
}
