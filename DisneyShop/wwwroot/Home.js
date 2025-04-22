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

    document.querySelector("#login-form button").addEventListener("click", logIn);
    document.querySelector("#register-form button").addEventListener("click", register);
    document.querySelector("#update-form button").addEventListener("click", updateUser);

});

// הפונקציה להתחברות
async function logIn() {
    const UserName = document.querySelector("#login-username").value;
    const password = document.querySelector("#login-password").value;

    try {
        const response = await fetch("api/Users/logIn", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ UserName: UserName, Password: password })
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            throw new Error(errorMessage || "שם משתמש או סיסמה שגויים");
        }

        const data = await response.json();
        alert("התחברת בהצלחה!");

        // שומרים את ה-UserId ב-localStorage
        if (data && data.userId) { // השתמש ב-userId עם u קטנה
            localStorage.setItem("userId", data.userId); // השתמש ב-userId עם u קטנה
            console.log("UserId saved:", data.userId); // הוספתי לוג לבדוק אם ה-UserId נשמר
        } else {
            console.log("UserId not found in response");
        }
        console.log("Response data:", data); 

        document.getElementById("login-form").classList.add("hidden");
        document.getElementById("update-form").classList.remove("hidden");

    } catch (err) {
        alert(err.message);
    }
}


// הפונקציה לרישום משתמש חדש
async function register() {
    const user = {
        userName: document.getElementById("register-username").value,
        password: document.getElementById("register-password").value,
        firstName: document.getElementById("first-name").value,
        lastName: document.getElementById("last-name").value
    };

    try {
        const response = await fetch("api/Users/register", { 
            method: "POST",
            body: JSON.stringify(user),
            headers: { "Content-Type": "application/json" }
        });
        if (!response.ok) {
            throw new Error("Registration failed");
        }
        alert("User registered successfully!");
    }
    catch (error) {
        console.log(error);
    }
}
async function updateUser() {
    const userNameInput = document.getElementById("update-UserName");
    const passwordInput = document.getElementById("update-Password");
    const firstNameInput = document.getElementById("update-FirstName");
    const lastNameInput = document.getElementById("update-LastName");

    if (!userNameInput || !passwordInput || !firstNameInput || !lastNameInput) {
        console.error("❌ אחד האלמנטים חסר! בדקי את ה-HTML");
        return;
    }

    const UserName = userNameInput.value;
    const Password = passwordInput.value;
    const FirstName = firstNameInput.value;
    const LastName = lastNameInput.value;

    const userId = localStorage.getItem("userId");
    if (!userId) {
        console.error("❌ UserId חסר ב-LocalStorage!");
        return;
    }

    const user = { id: userId, UserName, Password, FirstName, LastName };

    try {
        const response = await fetch(`api/Users/${userId}`, {
            method: 'PUT',
            body: JSON.stringify(user),
            headers: { 'Content-Type': "application/json" }
        });

        if (!response.ok) {
            throw new Error("❌ לא ניתן לשמור את הנתונים!");
        }

        console.log("✅ הנתונים נשמרו בהצלחה!");
        document.getElementById("successMessage").style.display = "block";
        setTimeout(() => {
            document.getElementById("successMessage").style.display = "none";
        }, 3000);
    } catch (error) {
        console.log("❌ שגיאה: ", error);
    }
}
