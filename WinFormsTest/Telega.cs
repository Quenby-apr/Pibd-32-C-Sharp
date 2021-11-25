using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
using TLSharp.Core;

namespace WinFormsTest
{
    public class Telega
    {

        public async void testing()
        {
            int apiId = 9153033;
            string apiHash = "99d35646363829a80ab8c28cd2044655";

            List<string> listPhones = new List<String>();
            var client = new TelegramClient(apiId, apiHash);
            await client.ConnectAsync();

            var hash = await client.SendCodeRequestAsync("89170637967");
            Console.WriteLine("gtdfgf");

            var codeForAuth = "68598";
            var userAuth = await client.MakeAuthAsync("89170637967", hash, codeForAuth);

            var userContacts = await client.GetContactsAsync();

            //Get phones from user
            foreach (var user in userContacts.Users)
            {
                var props = user.GetType().GetProperties();

                foreach (var prop in props)
                {
                    if (prop.Name == "Phone")
                    {
                        listPhones.Add(prop.GetValue(user).ToString());
                    }
                }
            }

            try
            {
                var selectUsersForSendMessage = userContacts.Users
                                                            .Where(x => x.GetType() == typeof(TLUser))
                                                            .Cast<TLUser>()
                                                            .FirstOrDefault(x => x.Phone == "89176046759");

                await client.SendMessageAsync(new TLInputPeerUser() { UserId = selectUsersForSendMessage.Id }, "атака начинается");
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при отправлении сообщения " + ex.Message);
            }
        }
    }
}
