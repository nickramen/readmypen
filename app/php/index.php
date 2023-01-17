<!doctype html>
<html lang="en">
    <head>
        <!-- Required meta tags -->
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

        <!-- Bootstrap CSS -->
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <link rel="stylesheet" href="../assets/css/styles.css" type="text/css">

        <title>Read My Pen!</title>
    </head>
    <body>
        <div class="container-fluid">
            <div class="row">
                <div class="col-12" id="div-title">
                    <h1>Read My Pen</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-5" id="div-box-title-1">
                    <h3>What are we reading?</h3>
                </div>
                <div class="col-sm-7" id="div-box-title-2">
                    <h3>Your Notes</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-5" id="div-box-content-1">
                    <div class="delete-box">
                        <i class="fa fa-close" id="closeicon" style="font-size:48px;" onclick="closeImage()"></i>
                    </div>
                    <!-- SELECT PICTURE FORM -->
                    <form action="../php/upload.php" method="post" enctype="multipart/form-data">
                        <div class="preview" id="div-image-displayer">
                            <!-- deleted position:absolute -->
                            <img id="preview-selected-image" name="preview-selected-image"  />
                        </div>
                        <div class="input-group" style="margin-top: 20px">
                            <div class="custom-file">
                                <label class="custom-file-label" for="file-upload">Choose file</label>
                                <input type="file" name="fileToUpload" class="custom-file-input" id="file-upload" accept="image/jpeg, image/png" onchange="previewImage(event);">
                            </div>
                            <div class="input-group-append">
                                <input class="btn btn-secondary" name="submit" type="submit" id="btnUpload" value="Upload" />
                            </div>
                        </div>
                    </form>
                </div>
                <div class="col-7" id="div-box-content-2">
                    <div id="div-text-editor">
                    </div>
                    <div style="margin-top: 20px">
                        <button class="btn btn-secondary" type="button">Generate</button>
                        <button class="btn btn-secondary" type="button">Copy to Clipboard</button>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Optional JavaScript -->
        <!-- jQuery first, then Popper.js, then Bootstrap JS -->
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
        <script src="../assets/js/display-image.js"></script>

    </body>
</html>