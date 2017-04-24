using System;

namespace Pomodoro.Models
{
    public class LoginModel
    {
        public string grant_type { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}