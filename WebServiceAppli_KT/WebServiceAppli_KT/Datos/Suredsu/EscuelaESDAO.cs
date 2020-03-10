using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class EscuelaESDAO
    {
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        ConexionAppliktDAO conexionApplikt = new ConexionAppliktDAO();
        MySqlConnection con;
        List<DetallePlantel> lstDetallePlantel;
        List<PlantelesES> lstPlantelesES;
        PlantelesES planteles;
        PlantelesEMS plantelems;
        DetallePlantel detallePlantel;

        public List<DetallePlantel> ObtenerDetallePlantel()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select * from bd_applikt.detalle_plantel";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lstDetallePlantel = new List<DetallePlantel>();
                while (reader.Read())
                {

                    lstDetallePlantel.Add(new DetallePlantel()
                    {
                        cve_detalle_plantel = Convert.ToInt32(reader["cve_detalle_plantel"].ToString()),
                        url_vinculacion = reader["url_vinculacion"].ToString(),
                        logo_plantel = reader["logo_plantel"].ToString(),
                        requisitos = reader["requisitos"].ToString(),
                        fecha_expedicion = reader["fecha_expedicion"].ToString(),
                        fechas_inscripcion = reader["fecha_inscripcion"].ToString(),
                        fecha_inicio = reader["fecha_inicio"].ToString(),
                        reseña = reader["reseña"].ToString(),
                        latitud = reader["latitud"].ToString(),
                        longitud = reader["longitud"].ToString(),
                        ubicacion = reader["ubicacion"].ToString(),
                        actividades_extracurriculares = reader["actividades_extracurriculares"].ToString(),
                        contacto = reader["contacto"].ToString(),
                        vinculacion = reader["vinculacion"].ToString(),
                        domicilio = reader["domicilio"].ToString(),
                        nombre_corto = reader["nombre_corto"].ToString(),
                        nombre_region = reader["nombre_region"].ToString(),
                        region = reader["region"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        cve_nivel_agrupado = reader["cve_nivel_agrupado"].ToString(),
                        cve_nivel_estudio = Convert.ToInt32(reader["cve_nivel_estudio"]),
                        idPlantelesES = Convert.ToInt32(reader["idPlantelesES"]),
                        cve_subsistema = Convert.ToInt32(reader["cve_subsistema"]),
                        idColonia = reader["idColonia"].ToString()
                    });
                }

                for (int i = 0; i < lstDetallePlantel.Count; i++)
                {
                    if (!string.IsNullOrEmpty(lstDetallePlantel[i].logo_plantel) || !lstDetallePlantel[i].logo_plantel.Equals("-"))
                    {
                        lstDetallePlantel[i].logo_plantel = ConvertImageURLToBase64("http://s-applikt.utleon.edu.mx/" + lstDetallePlantel[i].logo_plantel);
                    }
                }

                return lstDetallePlantel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<PlantelesES> ObtenerPlanteles()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select * from suredsu.planteleses";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lstPlantelesES = new List<PlantelesES>();
                while (reader.Read())
                {

                    lstPlantelesES.Add(new PlantelesES()
                    {
                        idPlantelES = Convert.ToInt32(reader["idPlantelES"].ToString()),
                        ClavePlantel = reader["ClavePlantel"].ToString(),
                        NombrePlantelES = reader["NombrePlantelES"].ToString(),
                        Subsistema = reader["Subsistema"].ToString(),
                        Sostenimiento = reader["Sostenimiento"].ToString(),
                        Municipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        Activo = reader["Activo"].ToString(),
                        ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                        NombreInstitucionES = reader["NombreInstitucionES"].ToString(),
                        OPD = reader["OPD"].ToString(),
                        NivelAgrupado = reader["NivelAgrupado"].ToString(),
                    });
                }
                return lstPlantelesES;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public String ConvertImageURLToBase64(String url)
        {

            if (url.Equals("http://s-applikt.utleon.edu.mx/-"))
            {
                return "-";
            }
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = this.GetImage(url);

            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return _sb.ToString();
        }

        private byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        public PlantelesES BuscarPlantelMunicipio(int idMunicipio)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "select * from planteleses where idMunicipio = @idMunicipio";
                cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    planteles = new PlantelesES()
                    {
                        idPlantelES = Convert.ToInt16(reader["idPlantelEs"].ToString()),
                        ClavePlantel = reader["ClavePlantel"].ToString(),
                        NombrePlantelES = reader["NombrePlantelES"].ToString(),
                        Subsistema = reader["Subsistema"].ToString(),
                        Sostenimiento = reader["Sostenimiento"].ToString(),
                        Municipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        Activo = reader["Activo"].ToString(),
                        ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                        NombreInstitucionES = reader["NombreInstitucionEs"].ToString(),
                        OPD = reader["OPD"].ToString(),
                        NivelAgrupado = reader["NivelAgrupado"].ToString()
                    };
                }
                return planteles;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public PlantelesES BuscarPlantelId(int idPlanteles)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "select * from planteleses where idPlantelES = @idPlanteles";
                cmd.Parameters.AddWithValue("@idPlanteles", idPlanteles);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    planteles = new PlantelesES()
                    {
                        idPlantelES = Convert.ToInt16(reader["idPlantelEs"].ToString()),
                        ClavePlantel = reader["ClavePlantel"].ToString(),
                        NombrePlantelES = reader["NombrePlantelES"].ToString(),
                        Subsistema = reader["Subsistema"].ToString(),
                        Sostenimiento = reader["Sostenimiento"].ToString(),
                        Municipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        Activo = reader["Activo"].ToString(),
                        ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                        NombreInstitucionES = reader["NombreInstitucionEs"].ToString(),
                        OPD = reader["OPD"].ToString(),
                        NivelAgrupado = reader["NivelAgrupado"].ToString()
                    };
                }
                return planteles;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public PlantelesES BuscarPlantel(string plantel)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "select * from planteleses where NombrePlantelES = @plantel";
                cmd.Parameters.AddWithValue("@plantel", plantel);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    planteles = new PlantelesES()
                    {
                        idPlantelES = Convert.ToInt16(reader["idPlantelEs"].ToString()),
                        ClavePlantel = reader["ClavePlantel"].ToString(),
                        NombrePlantelES = reader["NombrePlantelES"].ToString(),
                        Subsistema = reader["Subsistema"].ToString(),
                        Sostenimiento = reader["Sostenimiento"].ToString(),
                        Municipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        Activo = reader["Activo"].ToString(),
                        ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                        NombreInstitucionES = reader["NombreInstitucionEs"].ToString(),
                        OPD = reader["OPD"].ToString(),
                        NivelAgrupado = reader["NivelAgrupado"].ToString()
                    };
                }
                return planteles;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public PlantelesEMS BuscarPlantelIDPlantelEMS(int idplantel)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select  * from plantelesems where idPlantelEMS = @idPlantel";
                cmd.Parameters.AddWithValue("@idPlantel", idplantel);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    plantelems = new PlantelesEMS();
                    plantelems.idPlantelesEMS = Convert.ToInt32(reader["idPlantelEMS"].ToString());
                    plantelems.ClavePlantel = reader["ClavePlantel"].ToString();
                    plantelems.NombrePlantelEMS = reader["NombrePlantelEMS"].ToString();
                    plantelems.Subsistema = reader["Subsistema"].ToString();
                    plantelems.Sostenimiento = reader["Sostenimiento"].ToString();
                    plantelems.Control = reader["Control"].ToString();
                    plantelems.subcontrol = reader["subcontrol"].ToString();
                    plantelems.idMunicipio = Convert.ToInt32(reader["idMunicipio"].ToString());
                    plantelems.Activo = Convert.ToBoolean(reader["Activo"].ToString());
                    plantelems.subsistemaSices = reader["subsistemaSices"].ToString();
                    plantelems.Turno = reader["Turno"].ToString();
                }
                return plantelems;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public DetallePlantel BuscarDetallePlantel(string idPlantel)
        {
            try
            {
                var conn = conexionApplikt.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select * from detalle_plantel where idPlantelesES = @idPlantel";
                cmd.Parameters.AddWithValue("@idPlantel", idPlantel);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    detallePlantel = new DetallePlantel()
                    {
                        cve_detalle_plantel = Convert.ToInt32(reader["cve_detalle_plantel"].ToString()),
                        url_vinculacion = reader["url_vinculacion"].ToString(),
                        logo_plantel = reader["logo_plantel"].ToString(),
                        requisitos = reader["requisitos"].ToString(),
                        fecha_expedicion = reader["fecha_expedicion"].ToString(),
                        fechas_inscripcion = reader["fechas_inscripcion"].ToString(),
                        fecha_inicio = reader["fecha_inicio"].ToString(),
                        reseña = reader["reseña"].ToString(),
                        latitud = reader["latitud"].ToString(),
                        longitud = reader["longitud"].ToString(),
                        ubicacion = reader["ubicacion"].ToString(),
                        actividades_extracurriculares = reader["actividades_extracurriculares"].ToString(),
                        contacto = reader["contacto"].ToString(),
                        costos = reader["costos"].ToString(),
                        cve_imagen_plantel = Convert.ToInt32(reader["cve_imagen_plantel"].ToString()),
                        vinculacion = reader["vinculacion"].ToString(),
                        domicilio = reader["domicilio"].ToString(),
                        nivel_estudio = reader["nivel_estudio"].ToString(),
                        nombre_corto = reader["nombre_corto"].ToString(),
                        nombre_region = reader["nombre_region"].ToString(),
                        region = reader["region"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        cve_nivel_agrupado = reader["cve_nivel_agrupado"].ToString(),
                        cve_nivel_estudio = Convert.ToInt32(reader["cve_nivel_estudio"].ToString()),
                        idPlantelesES = Convert.ToInt32(reader["idPlantelesES"]),
                        cve_subsistema = Convert.ToInt32(reader["cve_subsistema"].ToString()),
                        idColonia = reader["idColonia"].ToString()
                    };
                }
                return detallePlantel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<ImagenPlantel> BuscarImagenPlantel(string idPlantel)
        {
            try
            {
                var conn = conexionApplikt.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select * from imagen_plantel where cve_detalle_plantel = @cveDetallePlantel";
                cmd.Parameters.AddWithValue("@cveDetallePlantel", idPlantel);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                var listImagenes = new List<ImagenPlantel>();
                while (reader.Read())
                {
                    var imagenPlantel = new ImagenPlantel()
                    {
                        cve_detalle_plantel =Convert.ToInt32(reader["cve_detalle_plantel"].ToString()),
                        cve_imagen_plantel = Convert.ToInt32(reader["cve_imagen_plantel"].ToString()),
                        descripcion = reader["descripcion"].ToString(),
                        imagen_principal = Convert.ToInt32(reader["imagen_principal"].ToString()),
                        ruta = reader["ruta"].ToString()
                };
                    
                    listImagenes.Add(imagenPlantel);
                    
                }
                for (int i = 0; i < listImagenes.Count; i++)
                {
                    listImagenes[i].ruta = ConvertImageURLToBase64("http://s-applikt.utleon.edu.mx/" + listImagenes[i].ruta);
                }
                return listImagenes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<ImagenPlantel> BuscarImagenPlanteles()
        {
            try
            {
                var conn = conexionApplikt.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select * from imagen_plantel";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                var listImagenes = new List<ImagenPlantel>();
                while (reader.Read())
                {
                    var imagenPlantel = new ImagenPlantel()
                    {
                        cve_detalle_plantel = Convert.ToInt32(reader["cve_detalle_plantel"].ToString()),
                        cve_imagen_plantel = Convert.ToInt32(reader["cve_imagen_plantel"].ToString()),
                        descripcion = reader["descripcion"].ToString(),
                        imagen_principal = Convert.ToInt32(reader["imagen_principal"].ToString()),
                        ruta = reader["ruta"].ToString()
                    };

                    listImagenes.Add(imagenPlantel);

                }
                for (int i = 0; i < listImagenes.Count; i++)
                {
                    Console.WriteLine("Imagen número: "+i);
                    listImagenes[i].ruta = ConvertImageURLToBase64("http://s-applikt.utleon.edu.mx/" + listImagenes[i].ruta);
                }
                return listImagenes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

    }
}