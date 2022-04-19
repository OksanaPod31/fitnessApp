using CodeBlogFitness.BL.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User {get;}

        /// <summary>
        /// Создать новый контроллер пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birdthDay, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birdthDay, weight, height );
        }

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TODO: Что делать, если пользователя не прочитали?
            }
        }

        /// <summary>
        /// Сохранить данные пользователя 
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);

            }
        }

        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <returns>Пользователь приложения</returns>
       
    }


}
