Begin
    INSERT INTO [dbo].[tblUser] ([Id], [FirstName], [LastName], [UserId], [Password])
    VALUES
        (1, 'John', 'Doe', 'johndoe', 'password1'),
        (2, 'Jane', 'Smith', 'janesmith', 'password2'),
        (3, 'Bob', 'Johnson', 'bobjohnson', 'password3')
End