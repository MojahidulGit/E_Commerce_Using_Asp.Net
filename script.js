document.getElementById("myForm").addEventListener("submit", function(event) {
    const username = document.getElementById("username").value.trim();
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value;
    const dob = document.getElementById("dob").value;
    const country = document.getElementById("country").value;
    const gender = document.querySelector('input[name="gender"]:checked');
    const fileUpload = document.getElementById("fileupload");

    // Username validation
    if (username === "" || username.length < 3 || username.length > 15) {
        alert("Username must be between 3 and 15 characters.");
        event.preventDefault();
        return;
    }
    // Email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        alert("Please enter a valid email address.");
        event.preventDefault();
        return;
    }
    // Password validation
    if (password.length < 2 || password.length > 16) {
        alert("Password must be between 2 and 16 characters.");
        event.preventDefault();
        return;
    }
    // Date of birth validation
    if (dob === "") {
        alert("Please select your date of birth.");
        event.preventDefault();
        return;
    }
    // Country validation
    if (country === "") {
        alert("Please select your country.");
        event.preventDefault();
        return;
    }    
    // Gender validation
    if (!gender) {
        alert("Please select your gender.");
        event.preventDefault();
        return;
    }
    // File upload validation
    if (fileUpload.files.length === 0) {
        alert("Please upload a file.");
        event.preventDefault();
        return;
    }
    const allowedExtensions = /(\.jpg|\.png|\.pdf)$/i;
    if (!allowedExtensions.test(fileUpload.value)) {
        alert("Only .jpg, .png, and .pdf files are allowed.");
        event.preventDefault();
        return;
    }
    alert("Form submitted successfully!");
});
document.getElementById("resetButton").addEventListener("click", function() {
    document.getElementById("myForm").reset();
    alert("Form has been reset!");
});