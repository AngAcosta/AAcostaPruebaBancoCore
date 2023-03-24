using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Banco
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaPruebaBancoContext context = new DL.AacostaPruebaBancoContext())
                {
                    var query = context.Bancos.FromSqlRaw("BancoGetAll").ToList();

                    if(query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Banco banco = new ML.Banco();

                            banco.IdBanco = obj.IdBanco;
                            banco.Nombre = obj.Nombre;
                            banco.NoEmpleados = obj.NoEmpleados.Value;
                            banco.NoSucursales = obj.NoSucursales.Value;

                            banco.Pais = new ML.Pais();
                            banco.Pais.IdPais = obj.IdPais.Value;
                            banco.Pais.Nombre = obj.Nombre;

                            banco.Capital = obj.Capital.Value;

                            banco.RazonSocial = new ML.RazonSocial();
                            banco.RazonSocial.IdRazonSocial = obj.IdRazonSocial.Value;
                            banco.RazonSocial.Nombre = obj.Nombre;

                            banco.NoClientes = obj.NoClientes.Value;

                            result.Objects.Add(banco);
                        }
                    }
                    result.Correct = true;
                }
            }catch (Exception ex)
            {

            }
            return result;
        }

        public static ML.Result Delete(int IdBanco)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaPruebaBancoContext context = new DL.AacostaPruebaBancoContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"BancoDelete '{IdBanco}'");

                    if (query != 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.Banco banco)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaPruebaBancoContext context = new DL.AacostaPruebaBancoContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"BancoAdd '{banco.Nombre}','{banco.NoEmpleados}','{banco.NoSucursales}','{banco.Pais.IdPais}','{banco.Capital}','{banco.RazonSocial.IdRazonSocial}','{banco.NoClientes}'");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Banco banco)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaPruebaBancoContext context = new DL.AacostaPruebaBancoContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"BancoUpdate '{banco.IdBanco}','{banco.Nombre}','{banco.NoEmpleados}','{banco.NoSucursales}','{banco.Pais.IdPais}','{banco.Capital}','{banco.RazonSocial.IdRazonSocial}','{banco.NoClientes}'");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}