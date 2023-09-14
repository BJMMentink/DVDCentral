Begin
    INSERT INTO [dbo].[tblUser] ([Id], [FirstName], [LastName], [UserName], [Password])
    VALUES
        (101, 'John', 'Doe', 'johndoe', 'password1'),
        (102, 'Jane', 'Smith', 'janesmith', 'password2'),
        (103, 'Bob', 'Johnson', 'bobjohnson', 'password3')
End