using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Consolka
{
    class Program
    {
        class Posilaem
        {
            public async static void Delaem()
            {
                // Replace sender@example.com with your "From" address. 
                // This address must be verified with Amazon SES.
                string FROM = "samir.itstep@gmail.com";
                string FROMNAME = "Mammadli Samir";

                // Replace recipient@example.com with a "To" address. If your account 
                // is still in the sandbox, this address must be verified.
                string TO = "samir4ik86@gmail.com";

                // Replace smtp_username with your Amazon SES SMTP user name.
                string SMTP_USERNAME = "samir.itstep";

                // Replace smtp_password with your Amazon SES SMTP user name.
                string SMTP_PASSWORD = "Temp12345";


                // If you're using Amazon SES in a region other than US West (Oregon), 
                // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
                // endpoint in the appropriate AWS Region.
                string HOST = "smtp.gmail.com";

                // The port you will connect to on the Amazon SES SMTP endpoint. We
                // are choosing port 587 because we will use STARTTLS to encrypt
                // the connection.
                int PORT = 587;

                // The subject line of the email
                String SUBJECT =
                    "This email automatically generated!";

                // The body of the email
                String BODY =
                    "<h1>Amazon SES Test</h1>" +
                    "<p>This email was sent through the " +
                    "<a href='https://aws.amazon.com/ses'>Amazon SES</a> SMTP interface " +
                    "using the .NET System.Net.Mail library.</p>";

                // Create and build a new MailMessage object
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(FROM, FROMNAME);
                message.To.Add(new MailAddress(TO));
                message.Subject = SUBJECT;
                message.Body = BODY;
                // Comment or delete the next line if you are not using a configuration set

                using (var client = new SmtpClient(HOST, PORT))
                {
                    // Pass SMTP credentials
                    client.Credentials =
                        new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                    // Enable SSL encryption
                    client.EnableSsl = true;

                    // Try to send the message. Show status in console.
                    try
                    {
                        Console.WriteLine("Attempting to send email...");
                        await client.SendMailAsync(message);
                        
                        Console.WriteLine("Email sent!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The email was not sent.");
                        Console.WriteLine("Error message: " + ex.Message);
                    }
                }
            }
        }

        class Dwedqw
        {
            public string Name { get; set; }
        }


        public class AccessTokenResult
        {
            public string Username { get; set; }
            public string Token { get; set; }
            public DateTime ExpireDate { get; set; }

            public AccessTokenResult(string username, string token, DateTime expireDate)
            {
                Username = username;
                Token = token;
                ExpireDate = expireDate;
            }

            public AccessTokenResult()
            {

            }
        }

        public enum ProjectUserRole
        {
            Owner = 0,
            Master = 1,
            Programmer = 2
        }

        static void Main(string[] args)
        {

            AccessTokenResult token = null;
            //Register();
            //ResendCode();
            CheckCode();
            //LogIn(ref token);
            //DeleteProject(token); 
            //CreateProject(token);
            //GetProjects(token);
            //AddUserToProject(token);
            //Authorize(token);
            //ResendCode();
            //AddRole();
            //Authorize();
            //GetCards();
            //AddUser();
            //ChangeUser();
            //GetUsers();
            //AddCard();
            //DeleteUsers(0);
            //Console.WriteLine("Before act: " + chislo.Name);
            //Console.WriteLine($"after act: {chislo.Name}");


            //Action<int> action = aga => Console.WriteLine(aga);

            //action.Invoke(1);

            //Console.WriteLine(DateTime.UtcNow.AddDays(1));
            //Posilaem.Delaem();
            //Console.ReadKey();
            //while (true) 
            //{
            //    AddUser();
            //    Console.ReadKey();
            //    Console.Clear();
            //}

            //var client = new RestClient("http://localhost:53117/");
            //var request = new RestRequest(Method.POST);
            //request.Resource = "api/set";
            //request.AddJsonBody(new Card { Text = "gnoy", Description = "say my name", ExpireDate = DateTime.Now });
            ////request.AddHeader("postman-token", "5f7903f0-845d-4ffe-45dd-5e33a9c69c9e");
            ////request.AddHeader("cache-control", "no-cache");
            ////request.AddHeader("content-type", "application/json");
            ////request.AddParameter("application/json", "@{Text = \"Bob\"; Description = \"gnoy\"}", ParameterType.RequestBody);
            //var response = client.Execute(request);
            //var ser = new JsonDeserializer();
            //var obj = ser.Deserialize<Card>(response);
            //Console.WriteLine(obj.Text);
            //Console.WriteLine(response.IsSuccessful);
        }

        static public void CreateProject(AccessTokenResult result)
        {
            Console.WriteLine("Enter name: ");
            var projectName = Console.ReadLine();
            var client = new RestClient("https://mammadli.info/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/project/add/project";
            request.AddJsonBody(projectName);
            //request.Resource = "home/index";
            if (result != null)
                request.AddHeader("Authorization", "Bearer " + result.Token);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
        }

        static public void AddUserToProject(AccessTokenResult result)
        {
            Console.WriteLine("Enter Project id: ");
            var id = Console.ReadLine();
            Console.WriteLine("Enter user email: ");
            var email = Console.ReadLine();
            var client = new RestClient("https://mammadli.info/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/project/add/user";
            request.AddJsonBody(new { UserEmail = email, ProjectId = id, Role = ProjectUserRole.Master});
            //request.Resource = "home/index";
            if (result != null)
                request.AddHeader("Authorization", "Bearer " + result.Token);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
        }

        static public void DeleteProject(AccessTokenResult result)
        {
            Console.WriteLine("Enter project id: ");
            var projectId = Console.ReadLine();
            var client = new RestClient("https://mammadli.info/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/project/delete/project";
            request.AddJsonBody(projectId);
            //request.Resource = "home/index";
            if (result != null)
                request.AddHeader("Authorization", "Bearer " + result.Token);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
        }

        static public void GetUsers()
        {
            var client = new RestClient("http://localhost:53117/");
            var request = new RestRequest(Method.GET);
            request.Resource = "api/users";
            var response = client.Execute(request);
            var ser = new JsonDeserializer();
            var obj = ser.Deserialize<List<User>>(response);
            if (obj != null)
            {
                foreach (var item in obj)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static public void CheckCode()
        {
            var client = new RestClient("https://localhost:44394/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/account/registration/confirm";
            Console.WriteLine("Enter email: ");
            var mail = Console.ReadLine();
            Console.WriteLine("Enter registration code: ");
            var regCode = Console.ReadLine();
            request.AddJsonBody(new { email = mail, code = regCode });
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
            //648495
        }

        static public void RenewCode(ref AccessTokenResult token)
        {

            var client = new RestClient("https://mammadli.info/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/account/renew";
            request.AddHeader("Authorization", "Bearer " + token.Token);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);

            if (response.StatusCode != HttpStatusCode.OK) return;
            var ser = new JsonDeserializer();
            var obj = ser.Deserialize<AccessTokenResult>(response);
            token = obj;
        }


        static public void Register()
        {
            Console.WriteLine("Enter Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Surname: ");
            var surname = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            var mail = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            var pass = Console.ReadLine();
            Console.WriteLine("Confirm password: ");
            var passcomf = Console.ReadLine();

            var client = new RestClient("https://mammadli.info/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/account/registration";
            request.AddJsonBody(new { Name = name, Email = mail, Password = pass, ConfirmPassword = passcomf, Surname = surname });
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);

        }

        static public void DeleteUsers(params int[] ids)
        {
            var client = new RestClient("http://localhost:53117/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/users/delete";
            request.AddJsonBody(ids);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);

        }


        static public void ResendCode()
        {
            var client = new RestClient("https://mammadli.info/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/account/registration/resend_code";
            Console.WriteLine("Enter email: ");
            var email = Console.ReadLine();
            request.AddJsonBody(email);
            var response  = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
        }

        static public void GetCards()
        {
            var client = new RestClient("http://localhost:53117/");
            var request = new RestRequest(Method.GET);
            request.Resource = "api/cards"; 
            var response = client.Execute(request);
            var ser = new JsonDeserializer();
            var obj = ser.Deserialize<List<Card>>(response);
            if (obj != null)
            {
                foreach (var item in obj)
                {
                    Console.WriteLine(item.Text);
                }
            }
        }

        static public void AddUser()
        {
            Console.WriteLine("Enter Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            var mail = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            var pass = Console.ReadLine();
            Console.WriteLine("Confirm password: ");
            var passcomf = Console.ReadLine();


            var client = new RestClient("https://mammadli.info/");
            var request = new RestRequest(Method.POST);
            request.Timeout = 15000;
            request.Resource = "api/users";
            request.AddJsonBody(new User { Name = name, Email = mail, Password = pass, ConfirmPassword = passcomf, PassHash = pass, Role = "admin" } );
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
        }

        static public void AddCard()
        {
            var client = new RestClient("http://localhost:53117/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/cards";
            request.AddJsonBody(new Card { Text = "Fignya" });
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
        }

        static public void ChangeUser()
        {
            var client = new RestClient("http://localhost:53117/");
            var request = new RestRequest(Method.PUT);
            request.Resource = "api/users";
            //request.AddJsonBody(new User { Id = 2, Name = "eblan4ik", Email = "sasmir@box.az", Password = "loshad", ConfirmPassword = "loshad" });
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
        }




        static public void AddRole()
        {
            var client = new RestClient("https://mammadli.info/");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/account/token";
            request.AddJsonBody(new User { Name = "Samir", Email = "rufet@bcdtravel.az", Password = "ujal550313", ConfirmPassword = "ujal550313", PassHash= "ujal550313" });
            var response = client.Execute(request);
            var ww = request.JsonSerializer.Serialize(new User { Name = "Samir", Email = "rufet@bcdtravel.az", Password = "ujal550313", ConfirmPassword = "ujal550313", PassHash = "ujal550313" });
            Console.WriteLine(ww);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);
        }

        static public void LogIn(ref AccessTokenResult result)
        {
            var client = new RestClient("https://mammadli.info/");//new RestClient("https://mammadli.info/");//new RestClient("https://localhost:44394");
            var request = new RestRequest(Method.POST);
            request.Resource = "api/account/login";
            Console.WriteLine("Enter email: ");
            var mail = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            var pass = Console.ReadLine();
            request.AddJsonBody(new { email = mail, password = pass });
            var response = client.Execute(request);

            
            if (!response.IsSuccessful)
                Console.WriteLine($"Error code: {response.Content}");
            else
                Console.WriteLine("Success!");

            if (response.StatusCode != HttpStatusCode.OK) return;
            var ser = new JsonDeserializer();
            var obj = ser.Deserialize<AccessTokenResult>(response);
            result = obj;
        }

        static public void GetProjects(AccessTokenResult result)
        {
            var client = new RestClient("https://mammadli.info/");//new RestClient("https://localhost:44394"); 
            var request = new RestRequest(Method.GET);
            request.Resource = "api/project";
            request.AddHeader("Authorization", "Bearer " + result.Token);
            var response = client.Execute(request);

            Console.WriteLine(response.StatusCode);
            //Console.WriteLine(response.Content);
            Console.WriteLine(response.IsSuccessful);

            if (response.StatusCode != HttpStatusCode.OK) return;
            var ser = new JsonDeserializer();
            var obj = ser.Deserialize<List<Project>>(response);
            Console.WriteLine("------------------------------------------------------------");
            foreach (var item in obj)
            {
                Console.WriteLine($"Id: {item.Id}" +
                    $"\nName: {item.Name}" +
                    $"\nData: {item.CreationDate}");
                Console.WriteLine("------------------------------------------------------------");
            }
        }



    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Column> Columns { get; set; }
        public List<Sprint> Sprints { get; set; }
        public List<Role> Roles { get; set; }

        public Project()
        {
            Roles = new List<Role>();
            Sprints = new List<Sprint>();
            Columns = new List<Column>();
        }
    }

    public class Column
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short ColumnType { get; set; }
        public Project Project { get; set; }
        public Sprint Sprint { get; set; }
        public List<Card> Cards { get; set; }

        public Column()
        {
            Cards = new List<Card>();
        }
    }

    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public DateTime ExpireDate { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
    }

    public class Role
    {
        public int Id { get; set; }
        public ProjectUserRole Type { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
    }

    public enum ProjectUserRole
    {
        Owner = 0,
        Master = 1,
        Programmer = 2
    }

    public class Card
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Column Column { get; set; }
        public Card()
        {

        }
    }   

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public string PassHash { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Email {Email}\n";
        }
    }
}
