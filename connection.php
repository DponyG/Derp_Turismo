<? 
$dbuser ='root';
$dbhost = 'localhost';
$dbport = 22;
$dbpassword = '';
$db = 'derp_turismo'


$connection = new mysqli($dbhost,$dbuser,$dbpassword, $db);

if(!$connection){
    die("Connection Failed", mysql_connect_error());
}
else {
    echo "Connected Fine";
}

