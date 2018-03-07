function UserValidate() {
    

    var fname = document.getElementById("firstname").value;
    var lname = document.getElementById("lastname").value;
    var uname = document.getElementById("username").value;
    var pwd1 = document.getElementById("password").value;
    var pwd2 = document.getElementById("password_two").value;
    var email = document.getElementById("emailInput").value;
    var phno = document.getElementById("phoneno").value;
    var temp = 0;
    document.getElementById("validation").style.visibility = "hidden";
    if (fname.length == 0 && lname.length == 0 && uname.length == 0 && pwd1.length == 0 && pwd2.length == 0 && document.getElementById("female").checked == false && document.getElementById("male").checked == false && document.getElementById("others").checked == false && phno.length == 0 && email.length == 0) {
        document.getElementById("validation").innerText = "All fields are manditory";

        document.getElementById("validation").style.visibility = "visible";
        temp++;

    }
    else if(fname.length == 0) {
        document.getElementById("validation").innerText = "Please enter Firstname";

        document.getElementById("validation").style.visibility = "visible";
        temp++;
    }
    else if (lname.length == 0) {
        document.getElementById("validation").innerText = "Please enter Lastname";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("lnamevalidation").style.visibility = "visible";
        temp++;
    }

    else if (uname.length == 0) {
        document.getElementById("validation").innerText = "Please enter Username";

        document.getElementById("validation").style.visibility = "visible";

        temp++;
    }
    else if (uname.length < 6 || uname.length > 20) {
        document.getElementById("validation").innerText = "User name must be minimum 6 characters and maximum 20 characters";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("unamelength").style.visibility = "visible";
        temp++;
    }

    else if (pwd1.length == 0) {
        document.getElementById("validation").innerText = "Please enter Password";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwd1validation").style.visibility = "visible";
        temp++;
    }
    else if (pwd1.length < 6 || pwd1.length > 20) {
        document.getElementById("validation").innerText = "Password must be minimum 6 characters and maximum 20 characters";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwdlength").style.visibility = "visible";
        temp++;
    }
    else if (!(/^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&.*])[a-zA-Z0-9!@#$%^&.*]{6,20}$/.test(pwd1))) {
        document.getElementById("validation").innerText = "Password must include atleast one letter,number and special character";

        document.getElementById("validation").style.visibility = "visible";
        //alert("alert");
        //document.getElementById("pwdformat").style.visibility = "visible";
        temp++;
    }

    else if (pwd2.length == 0) {
        document.getElementById("validation").innerText = "Please enter Confirm Password";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwd2validation").style.visibility = "visible";
        temp++;
    }

    else if (pwd1 != pwd2) {
        document.getElementById("validation").innerText = "Password mismatch";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwdcomparevalidation").style.visibility = "visible";
        temp++;
    }
    else if (document.getElementById("female").checked == false && document.getElementById("male").checked == false && document.getElementById("others").checked == false) {
        document.getElementById("validation").innerText = "Please enter Gender";

        document.getElementById("validation").style.visibility = "visible"
        //document.getElementById("gendervalidation").style.visibility = "visible";
        temp++;
    }
    else if (email.length == 0) {
        document.getElementById("validation").innerText = "Please enter Email";
        ;
        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("emailvalidation").style.visibility = "visible";
        temp++;
    }
    
    else if (!(/^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test(email))) {
        document.getElementById("validation").innerText = "Please enter valid email";

        document.getElementById("validation").style.visibility = "visible"
        //    //document.getElementById("evalidation").style.visibility = "visible";
        temp++;
    }

        
    else if (phno.length == 0) {
        document.getElementById("validation").innerText = "Please enter Phone Number";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("phnovalidation").style.visibility = "visible";
        temp++;
    }
    else if (phno.length != 10) {
        document.getElementById("validation").innerText = "Please enter valid Phone Number";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("phvalidation").style.visibility = "visible";
        temp++;
        
    }
    else if (!(/^[0-9]+$/.test(phno))) {
        document.getElementById("validation").innerText = "Please enter valid Phone Number";

        document.getElementById("validation").style.visibility = "visible"
        //    //document.getElementById("evalidation").style.visibility = "visible";
        temp++;
    }


    if (temp > 0)

        return false;
    return true;
    
    
}

function ForgotPassword() {
    //alert("hi");
    var uname = document.getElementById("username").value;
    var email = document.getElementById("emailInput").value;
    var phno = document.getElementById("phoneno").value;
    var pwd1 = document.getElementById("pwd1").value;
    var temp = 0;

    if (uname.length == 0 && phno.length == 0 && email.length == 0 && pwd1.length==0) {
        document.getElementById("validation").innerText = "All fields are mandatory";

        document.getElementById("validation").style.visibility = "visible";
        temp++;

    }
    else if (uname.length == 0) {
        document.getElementById("validation").innerText = "Please enter Username";

        document.getElementById("validation").style.visibility = "visible";

        temp++;
    }
   else if (email.length == 0) {
        document.getElementById("validation").innerText = "Please enter Email";
        ;
        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("emailvalidation").style.visibility = "visible";
        temp++;
    }
   else if (phno.length == 0) {
        document.getElementById("validation").innerText = "Please enter Phone Number";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("phnovalidation").style.visibility = "visible";
        temp++;
    }
   else if (pwd1.length == 0) {
        document.getElementById("validation").innerText = "Please enter Password";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwd1validation").style.visibility = "visible";
        temp++;
    }
    else if (pwd1.length < 6 || pwd1.length > 20) {
        document.getElementById("validation").innerText = "Password must include atleast one Uppercase letter, number ,special character and without white spaces ";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwdlength").style.visibility = "visible";
        temp++;
    }
    else if (!(/^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&.*])[a-zA-Z0-9!@#$%^&.*]{6,20}$/.test(pwd1))) {
        document.getElementById("validation").innerText = "Password must include atleast one Uppercase letter, number ,special character and without white spaces ";

        document.getElementById("validation").style.visibility = "visible";
        //alert("alert");
        //document.getElementById("pwdformat").style.visibility = "visible";
        temp++;
    }
    if (temp > 0)

        return false;
    return true;



}

function UserProfileValidate() {



    var fname = document.getElementById("firstname").value;
    var lname = document.getElementById("lastname").value;
    //var uname = document.getElementById("username").value;
    var pwd1 = document.getElementById("password").value;
    var pwd2 = document.getElementById("password_two").value;
    var email = document.getElementById("emailInput").value;
    var phno = document.getElementById("phoneno").value;
    var temp = 0;
    document.getElementById("validation").style.visibility = "hidden";
    if (fname.length == 0 && lname.length == 0 && pwd1.length == 0 && pwd2.length == 0 && phno.length == 0 && email.length == 0) {
        document.getElementById("validation").innerText = "All fields are manditory";

        document.getElementById("validation").style.visibility = "visible";
        temp++;

    }
    else if (fname.length == 0) {
        document.getElementById("validation").innerText = "Please enter Firstname";

        document.getElementById("validation").style.visibility = "visible";
        temp++;
    }
    else if (lname.length == 0) {
        document.getElementById("validation").innerText = "Please enter Lastname";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("lnamevalidation").style.visibility = "visible";
        temp++;
    }

    
   

    else if (pwd1.length == 0) {
        document.getElementById("validation").innerText = "Please enter Password";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwd1validation").style.visibility = "visible";
        temp++;
    }
    else if (pwd1.length < 6 || pwd1.length > 20) {
        document.getElementById("validation").innerText = "Password length be minimum 6 characters and maximum 20 characters Password must not include white spaces";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwdlength").style.visibility = "visible";
        temp++;
    }
    else if (!(/^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&.*])[a-zA-Z0-9!@#$%^&.*]{6,20}$/.test(pwd1))) {
        document.getElementById("validation").innerText = "Password must include atleast one Uppercase letter, number ,special character and without white spaces";

        document.getElementById("validation").style.visibility = "visible";
        //alert("alert");
        //document.getElementById("pwdformat").style.visibility = "visible";
        temp++;
    }

    else if (pwd2.length == 0) {
        document.getElementById("validation").innerText = "Please enter Confirm Password";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwd2validation").style.visibility = "visible";
        temp++;
    }

    else if (pwd1 != pwd2) {
        document.getElementById("validation").innerText = "Password mismatch";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("pwdcomparevalidation").style.visibility = "visible";
        temp++;
    }
    
    else if (email.length == 0) {
        document.getElementById("validation").innerText = "Please enter Email";
        ;
        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("emailvalidation").style.visibility = "visible";
        temp++;
    }

    else if (!(/^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test(email))) {
        document.getElementById("validation").innerText = "Please enter valid email";

        document.getElementById("validation").style.visibility = "visible"
        //    //document.getElementById("evalidation").style.visibility = "visible";
        temp++;
    }


    else if (phno.length == 0) {
        document.getElementById("validation").innerText = "Please enter Phone Number";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("phnovalidation").style.visibility = "visible";
        temp++;
    }
    else if (phno.length != 10) {
        document.getElementById("validation").innerText = "Please enter valid Phone Number";

        document.getElementById("validation").style.visibility = "visible";
        //document.getElementById("phvalidation").style.visibility = "visible";
        temp++;

    }
    else if (!(/^[0-9]+$/.test(phno))) {
        document.getElementById("validation").innerText = "Please enter valid Phone Number";

        document.getElementById("validation").style.visibility = "visible"
        //    //document.getElementById("evalidation").style.visibility = "visible";
        temp++;
    }


    if (temp > 0)

        return false;
    return true;


}

