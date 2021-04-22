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
        public static String FBsql = "and Time(time)>Time(date_sub(now(),INTERVAL 90 second)) and Date(time) = Date(now())";

        public static String getCodeGmail(String sim_id,String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                content = getMessage(conn, sim_id, sql,"Google", "or originator_address ='Google' or originator_address ='GOOGLE'");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        String temp = arr[i].Substring(arr[i].Length - 6, 6);
                        code = Int32.Parse(temp) + "";
                        Console.WriteLine("Message: " + content);
                        return temp;

                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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

        public static String getCodeBigo(String sim_id, String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                content = getMessage(conn, sim_id, sql, "BIGO", "");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        String temp = arr[i];
                        code = Int32.Parse(temp) + "";
                        Console.WriteLine("Message: " + content);
                        return temp;

                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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
        public static String getCodeGrap(String sim_id, String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                content = getMessage(conn, sim_id, sql, "GRAP", "");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        String temp = arr[i];
                        code = Int32.Parse(temp) + "";
                        Console.WriteLine("Message: " + content);
                        return temp;

                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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
        public static String getCodeWhatsapp(String sim_id,String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                content = getMessage(conn, sim_id, sql,"WHATSAPP","");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        
                        code = Int32.Parse(arr[i]) + "";
                        Console.WriteLine("Message: " + content);
                        return arr[i];

                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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
        public static String getCodeLine(String sim_id, String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {

                content = getMessage(conn, sim_id, sql, "LINE","");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        String temp = arr[i].Substring(arr[i].Length - 6, arr[i].Length);
                        code = Int32.Parse(temp) + "";
                        Console.WriteLine("Message: " + content);
                        return temp;

                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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
        public static String  getCodeFacebook(String sim_id,String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                content = getMessage(conn, sim_id, sql,"FACEBOOK","");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        code = Int32.Parse(arr[i]) + "";
                        Console.WriteLine("Message: " + content);
                        return arr[i];
                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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

        public static String getcodeUber(String sim_id, String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                content = getMessage(conn, sim_id, sql, "UBER", "");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        code = Int32.Parse(arr[i]) + "";
                        Console.WriteLine("Message: " + content);
                        return arr[i];
                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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

        public static String getCodeSkype(String sim_id, String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                content = getMessage(conn, sim_id, sql, "VERIFY","or originator_address ='SKYPE' or originator_address ='MICROSOFT'");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        code = Int32.Parse(arr[i]) + "";
                        Console.WriteLine("Message: " + content);
                        return arr[i];
                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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
        public static String getCodeViper(String sim_id, String sql)
        {
            String code = "";
            String content = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                content = getMessage(conn, sim_id, sql, "ITCVERIFY","or originator_address ='VIBER'");
                String[] arr = content.Split(" ");

                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {
                        
                        code = Int32.Parse(arr[i]) + "";
                        
                        Console.WriteLine("Message: " + content);
                        return arr[i];
                    }
                    catch (Exception e)
                    {

                        continue;
                    }
                }

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
                String sql = "SELECT stop FROM stop LIMIT 1";
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
        public static String getMessage(MySqlConnection conn,String simID, String sql,String app,String neu)
        {
            String code = "";
            String a = " ";
            String sql1 = "SELECT * FROM sms_table where sim_serial = '" + simID + "' and (originator_address LIKE'%"+app+"%' "+ neu+") "+sql+" order by id desc limit 1;";
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
                      
                        content = reader.GetString(3);
                        Console.WriteLine("Message: " + content);
                        content = content.Replace("-", "");
                        content = content.Replace(".", " ");
                        content = content.Replace("\n", " ");
                        return content;
                       
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

        public void insertStatus(MySqlConnection conn,String simID,String appname,String status,String error)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO status(sim_serial,app_name,status,error_name) VALUES(@sim_serial,@app_name,@status,@error_name)";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@sim_serial", simID);
            cmd.Parameters.AddWithValue("@app_name", appname);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@error_name", error);
            cmd.ExecuteNonQuery();
        }
    }
}
