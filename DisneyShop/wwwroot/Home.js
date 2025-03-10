

document.getElementById("switch-to-register").addEventListener("click", function (event) {
    event.preventDefault(); // מונע רענון דף

    document.getElementById("login-form").classList.add("hidden");
    document.getElementById("register-form").classList.remove("hidden");
});
login = async () => {
    const name = document.querySelector("#name").value;
    const password = document.querySelector("#password").value;

    try {
        const response = await fetch("https://localhost:44371/api/User/login", { // ודאי שהנתיב נכון
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ name, password })
        });

        if (!response.ok) {
            throw new Error("שם משתמש או סיסמה שגויים");
        }

        const data = await response.json(); // נניח שהשרת מחזיר טוקן או מידע על המשתמש
        alert("התחברת בהצלחה!"); // אפשר להפנות לדף אחר במקום alert
    } catch (err) {
        alert(err.message);
    }
};
const register = async () => {
    const name = document.querySelector("#name").value;
    const password = document.querySelector("#password").value;
    const lastName = document.querySelector("#lastName").value;
    const firstName = document.querySelector("#firstName").value;

    try {
        const response = await fetch("https://localhost:44371/api/User/register", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ name, password, lastName, firstName })
        });

        const data = await response.json();

        if (!response.ok) {
            throw new Error(data.message || "הרשמה נכשלה, נסי שנית");
        }


        alert("ההרשמה בוצעה בהצלחה! 🎉");
    } catch (err) {
        alert(err.message);
    }
};

//const userToUpdate = async () => {
//    const name ?= document.querySelector("#name").value,
//    const password = document.querySelector("#password").value;
//    const lastName = document.querySelector("#lastName").value;
//    const firstName = document.querySelector("#firstName").value;

//    try {
//        const response = await fetch("https://localhost:44371/api/User/register", {
//            method: "POST",
//            headers: {
//                "Content-Type": "application/json"
//            },
//            body: JSON.stringify({ name, password, lastName, firstName })
//        });

//        const data = await response.json();

//        if (!response.ok) {
//            throw new Error(data.message || "הרשמה נכשלה, נסי שנית");
//        }


//        alert("ההרשמה בוצעה בהצלחה! 🎉");
//    } catch (err) {
//        alert(err.message);
//    }




//}

