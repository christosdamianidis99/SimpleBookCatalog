IF NOT EXISTS (SELECT 1 FROM UserAccounts WHERE user_name = 'admin')
BEGIN
    INSERT INTO UserAccounts (user_name, email, password, role, is_verified, first_name, last_name, phone_number, profile_picture_url)
    VALUES 
    (
        'admin', -- Username
        'admin@example.com', -- Email
        'Admin@123', -- Replace with a hashed password or secure default
        'Admin', -- Role
        1, -- Is Verified
        'System', -- First Name
        'Administrator', -- Last Name
        NULL, -- Phone Number (optional)
        NULL -- Profile Picture URL (optional)
    )
END
