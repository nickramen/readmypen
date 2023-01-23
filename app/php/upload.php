<?php


    // Check if image file is a actual image or fake image
    if(isset($_POST["submit"])) {

        $target_dir = "uploads/";
        $date = date('dmy-his');
        $target_file = $target_dir . $date . '.' . pathinfo($_FILES["fileToUpload"]["name"],PATHINFO_EXTENSION);
        $uploadOk = 1;
        $imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));


        $check = getimagesize($_FILES["fileToUpload"]["tmp_name"]);
        if($check !== false) {
            // echo "File is an image - " . $check["mime"] . ".";
            $uploadOk = 1;
        } else {
            // echo "File is not an image.";
            $uploadOk = 0;
        }

        // Check if $uploadOk is set to 0 by an error
        if ($uploadOk == 0) {
            echo "Sorry, your file was not uploaded.";
        // if everything is ok, try to upload file
        } else {
            move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file);
    
            $path = $target_file;
            echo "<script>
                    
                    localStorage.setItem('path', '$path');
                    window.location.href = 'index.php';
                    
                </script>";

            // if(isset($_POST['submit'])){
            //     $path = $target_file;
            //     echo "<script>
            //         localStorage.setItem('path', '$path');
            //         window.location.href = 'index.html';
            //     </script>";
            // }
    
        }
    }

?>