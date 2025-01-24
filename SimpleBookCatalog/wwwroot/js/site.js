function togglePasswordVisibility() {
    var passwordInput = document.getElementById("passwordInput");
    var checkbox = document.getElementById("showPasswordCheckbox");

    // Check if the elements are found
    if (!passwordInput || !checkbox) {
        console.error("Password input or checkbox not found!");
        return;
    }

    // Toggle the password input type
    passwordInput.type = checkbox.checked ? "text" : "password";
}
