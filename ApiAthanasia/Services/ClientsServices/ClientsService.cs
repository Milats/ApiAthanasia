using ApiAthanasia.Models;
using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Tools;

namespace ApiAthanasia.Services.ClientsServices
{
    public class ClientsService : IClientsService
    {
        public static Response EmptyPasswords(List<UserClient> userList)
        {
            List<UserClient> users = new List<UserClient>();
            Response R = new Response();
            foreach (UserClient user in userList)
            {
                user.Password = "Empty";
                users.Add(user);
            }
            R.Data = users;
            return R;
        }
        public Response Add(NewClientRequest client)
        {
            Response R = new Response();
            using (AthanasiaContext DB = new AthanasiaContext())
            {
                using (var transaction = DB.Database.BeginTransaction())
                {
                    try
                    {
                        var newClient = new UserClient();
                        newClient.Cedula = client.cedula;
                        newClient.Name = client.name;
                        if (client.email != "")
                        {
                            newClient.Email = client.email;
                        } else
                        {
                            newClient.Email = "No Email";
                        }
                        if (client.password != "")
                        {
                            newClient.Password = Encrypt.GetSHA256(client.password);
                        }
                        else
                        {
                            newClient.Password = "No Password";
                        }
                        DB.UserClients.Add(newClient);
                        DB.SaveChanges();
                        R.Success = true;
                        R.Message = "AddClient succesful";
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        R.Message = ex.Message;
                    }
                    return R;
                }
            }
        }
        public Response UpdateClient(UpdateUserRequest request, int id)
        {
            Response R = new Response();
            using (AthanasiaContext DB = new AthanasiaContext())
            {
                try
                {
                    var client = DB.UserClients.Find(id);
                    if (client != null)
                    {
                        client.Name = request.Name;
                        DB.UserClients.Update(client);
                        DB.SaveChanges();
                        R.Success = true;
                        R.Message = "Client " + id + " updated succesfully";
                    } else
                    {
                        R.Message = "Client doesn't exists";
                    }
                }
                catch (Exception ex)
                {
                    R.Message = ex.Message;
                }
                return R;
            }
        }
        public Response DeleteClient(int id)
        {
            Response R = new Response();
            using (AthanasiaContext DB = new AthanasiaContext())
            {
                try
                {
                    var client = new UserClient();
                    client = DB.UserClients.Find(id);
                    DB.UserClients.Remove(client);
                    DB.SaveChanges();
                    R.Success = true;
                    R.Message = "Client " + id + " deleted succesfully";
                }
                catch (Exception ex)
                {
                    R.Message = ex.Message;
                }
                return R;
            }
        }
    }
}