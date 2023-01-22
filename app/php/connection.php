<!-- <?php

class Conection{

    function ConnectionDB(){

        $host = "DESKTOP-N8HS364\SQLEXPRESS";
        $dbname = "readmypen";
        $uid = "";
        $pass = "";
        $port = "";

        // $connection = [
        //     "Database" => $dbname,
        //     "Uid" => $uid,
        //     "PWD" => $pass
        // ];

        // $conn = sqlsrv_connect($host,$connection);
        // if(!$conn)
        //     die(print_r(sqlsrv_erros(),true));
        // else
        //     echo 'connection establihs';

        try{

            $conn = new PDO("sqlsrv:Server=$host,$port; database=$dbname;", $uid, $pass);
            echo "Se conecto";
        }
        catch(PDOException $exp){
            echo ("No se conecto $exp");
        }

        return $conn;
    }
}

?> -->