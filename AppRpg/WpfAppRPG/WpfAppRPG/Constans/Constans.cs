namespace WpfAppRPG
{
    public static class Constans
    {
        public static string ConnectionString => @"Server=localhost;Database=RpgBase;Trusted_Connection=True;";
        public static string AddPerson => "INSERT INTO [person] VALUES (@name, @nation, @level, @gender, @id)";
        public static string GetPerson => "SELECT * FROM [person]";
        public static string EditPerson => "UPDATE [person] SET [P_Name] = @name, [p_Nation] = @nation, [p_Lvl] = @level, [p_Gender] = @gender, [u_ID] = @id WHERE [p_ID] = @p_id";
        public static string GetUser => "SELECT * FROM [user] WHERE [u_Name] = @login and [u_Pass] = @password";
        public static string AddUser => "INSERT INTO [USER] VALUES (@login, 'fafjadf@govno.com', @password)";
    }
}
