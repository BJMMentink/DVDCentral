Begin
    INSERT INTO [dbo].[tblUser] ([Id], [FirstName], [LastName], [UserId], [Password])
    VALUES
        (201, 'John', 'Doe', 'johndoe', 103, 'password1'),
        (202, 'Jane', 'Smith', 'janesmith', 203,  'password2'),
        (203, 'Bob', 'Johnson', 'bobjohnson', 303, 'password3')
End