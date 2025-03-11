document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("switch-to-register").addEventListener("click", function (event) {
        event.preventDefault();
        document.getElementById("login-form").classList.add("hidden");
        document.getElementById("register-form").classList.remove("hidden");
    });

    document.getElementById("switch-to-login").addEventListener("click", function (event) {
        event.preventDefault();
        document.getElementById("register-form").classList.add("hidden");
        document.getElementById("login-form").classList.remove("hidden");
    });

    document.querySelector("#login-form button").addEventListener("click", login);
    document.querySelector("#register-form button").addEventListener("click", register);
});

// הפונקציה להתחברות
async function login() {
    const name = document.querySelector("#login-username").value;
    const password = document.querySelector("#login-password").value;

    try {
        const response = await fetch("https://localhost:44371/api/User/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ Name: name, Password: password })
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            throw new Error(errorMessage || "שם משתמש או סיסמה שגויים");
        }

        const data = await response.json();
        alert("התחברת בהצלחה!");
        console.log(data); // אפשר לעשות כאן הפניה לדף אחר
    } catch (err) {
        alert(err.message);
    }
}

// הפונקציה לרישום משתמש חדש
async function register() {
    const name = document.querySelector("#register-username").value;
    const password = document.querySelector("#register-password").value;
    const firstName = document.querySelector("#first-name").value;
    const lastName = document.querySelector("#last-name").value;

    try {
        const response = await fetch("https://localhost:44371/api/User/register", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ Name: name, Password: password, FirstName: firstName, LastName: lastName })
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            throw new Error(errorMessage || "הרשמה נכשלה, נסי שנית");
        }

        alert("ההרשמה בוצעה בהצלחה! 🎉");
    } catch (err) {
        alert(err.message);
    }
}
