function validateForm() {
   
    var fnamevalue = document.getElementById("UserFirstName").value;
    var lnamevalue = document.getElementById("UserLastName").value;
    var emailvalue = document.getElementById("UserEmail").value;
    var statevalue = document.getElementById("UserState").value;
    var phonevalue = document.getElementById("UserPhone").value;
    var drinkvalue = document.getElementById("UserDrink").value;
    var pwdvalue1 = document.getElementById("UserPassword1").value;
    var pwdvalue2 = document.getElementById("UserPassword2").value;
    var phoneverify = /^[\d\.\-]+$/;

    if (fnamevalue == "" || lnamevalue == "" || drinkvalue == "" || statevalue =="")
    {
        alert("Please fill out all fields!");
        return false;
    }

    if (emailvalue == '' || emailvalue.indexOf('@') == -1 || emailvalue.indexOf('.') == -1)
    {
        alert("Please enter a valid address!");
        return false;
    }

    if(!phoneverify.test(phonevalue))   
    {  
        alert("Please enter a valid phone number!");  
        return false;  
    }

    if (pwdvalue1 == "" || pwdvalue2 == "" || pwdvalue1 != pwdvalue2)
    {
        alert("Please enter matching passwords!");
        return false;
    }
}