<?php
 
$dbuser = 'root';
$dbpassword = '';
$db = 'derp_turismo';
$dbhost = 'localhost';
$dbport = 3306;

$user_email = $_POST["email"];
$user_password = $_POST["password"];

$connection = new mysqli($dbhost, $dbuser, $dbpassword, $db);

if (!$connection) {
    die("Connection Failed. ". mysqli_connect_error());
    
}

$query = "SELECT password FROM player WHERE email = '".$user_email."' " ;
$result = mysqli_query($connection, $query);

if(mysqli_num_rows($result) > 0) {
    while($row = mysqli_fetch_assoc($result)){
        if($row['password'] == $user_password){
            echo "login success ";
            echo "password is ". $row['password'];
        } else {
            echo "password incorrect";
            echo "password is ". $row['password'];
        }
    }
}
else {
    echo "user not found";
}
                  
?>