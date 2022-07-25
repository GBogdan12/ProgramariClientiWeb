<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clienti.aspx.cs" Inherits="proiect1.Clienti1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

        <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css"/>

    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">

    <!-- jQuery library -->
   <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <!-- Popper JS -->
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js"></script>

    <script type='text/javascript' src="https://rawgit.com/RobinHerbots/jquery.inputmask/3.x/dist/jquery.inputmask.bundle.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.1/moment.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/js/bootstrap-datetimepicker.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/css/bootstrap-datetimepicker.min.css"/>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.11.3/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.3/jquery-ui.js"></script>
    
    <script type="text/javascript" src="//code.jquery.com/jquery-1.11.3.min.js"></script>
<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>



     <div class="row">
            <div class="col-sm-12 col-md-12">
                <div class="card">
                    <div class="card-header">
                        <div class="card-tools"><button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse"><i class="fas fa-minus"></i></button></div>
                    </div>
                    <div class="card-body">
                        <div class="row">                         
                            <div class="col-sm-4 col-md-4">
                                   <div class="form-group">
                                       <input type="hidden" id="hIdClient"  />
                                    <button type="button" class="btn btn-block btn-primary" onclick="loadClienti()">Reincarca</button>
                                </div>
                            </div>
                             <div class="col-sm-4 col-md-4">
                                   <div class="form-group">
                                    <button type="button" class="btn btn-block btn-primary" onclick="adaugaClient()">Adauga</button>
                                </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
     <div class="card-body" id="listaClienti"></div>
    <div class="card-footer"></div>



     <div class="modal fade" id="modal-form-client">  
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="overlay"  id="modal-form-perioadaindisp-overlay">
                        <i class="fas fa-2x fa-sync fa-spin"></i>
                    </div>
                    <div class="modal-header">
                        <h4 class="modal-title" id="modal-form-programari-title">Editare Client</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="txtDenNume">Nume</label>
                            <input type="text" class="form-control form-control-border" id="txtNume" data-mask id="txtNume"/>
                        </div>
                        <div class="form-group">
                            <label for="txtDenPrenume">Prenume</label>
                            <input type="text" class="form-control form-control-border" id="txtPrenume" autocomplete="off" data-mask id="txtPrenume"/>
                        </div>
                        <div class="form-group">
                            <label for="txtDenMail">Mail</label>
                            <input type="text" class="form-control form-control-border" id="txtMail" autocomplete="off" data-mask id="txtMail"/>
                        </div>
                        <div class="form-group">
                            <label for="txtDenTelefon">Telefon</label>
                            <input type="text" class="form-control form-control-border" id="txtTelefon" autocomplete="off" data-mask id="txtTelefon" />
                        </div>
    
                        <input type="hidden" id="hIdClient"  />
                    </div>
                       
                    <div class="modal-footer justify-content-between">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Renunta</button>
                        <button type="button" class="btn btn-success" onclick="SaveClient()">Salveaza</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->



    <script>

        $(document).ready(function () {
            
            loadClienti();
        });

        function loadClienti() {
            listaClienti.innerHTML = "";
            var data = document.getElementById("#listaClienti");
        var paramData = {
            data: data,
            };

        $.ajax({
            type: "POST",
            url: "Clienti.aspx/GetClienti",
            data: JSON.stringify(paramData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            cache: false,
            success: function (response) {
                var rasp = response.d;

                if (rasp) {


                    var rv = rasp.data;
                    if (rv.length > 0) {
                        var tbl = document.createElement("table");
                        tbl.setAttribute("id", "tblClienti");
                        tbl.setAttribute("class", "table table-bordered table-striped");
                        listaClienti.appendChild(tbl);

                        var thead = document.createElement("thead");
                        tbl.appendChild(thead);

                        var tr = document.createElement("tr");
                        tr.setAttribute("style", "background-color: #0068b1; color: #FFFFFF; font-weight: bold;");
                        thead.appendChild(tr);

                        var th = document.createElement("th");
                        th.innerHTML = "Prenume";
                        tr.appendChild(th);

                        th = document.createElement("th");
                        th.innerHTML = "Nume";
                        tr.appendChild(th);

                        th = document.createElement("th");
                        th.innerHTML = "Telefon";
                        tr.appendChild(th);

                        th = document.createElement("th");
                        th.innerHTML = "Mail";
                        tr.appendChild(th);

                        th = document.createElement("th");
                        th.innerHTML = "Editare";
                        tr.appendChild(th);

                        th = document.createElement("th");
                        th.innerHTML = "Stergere";
                        tr.appendChild(th);

                        var tbody = document.createElement("tbody");
                        tbl.appendChild(tbody);

                        for (var i = 0; i < rv.length; i++) {
                            var rez = rv[i];

                            tr = document.createElement("tr");
                            tbody.appendChild(tr);


                            td = document.createElement("td");
                            td.innerHTML = rez.Prenume;
                            tr.appendChild(td);

                            td = document.createElement("td");
                            td.innerHTML = rez.Nume;
                            tr.appendChild(td);

                            td = document.createElement("td");
                            td.innerHTML = rez.Telefon;
                            tr.appendChild(td);

                            td = document.createElement("td");
                            td.innerHTML = rez.Mail;
                            tr.appendChild(td);

                            td = document.createElement("td");
                            td.setAttribute("style", "text-align: center;");
                            tr.appendChild(td);

                            var aEdit = document.createElement("a");
                            aEdit.setAttribute("style", "cursor: pointer");
                            aEdit.setAttribute("data-idClient", rez.Id)
                            aEdit.setAttribute("onclick", "OpenFormClient(this)");
                            td.appendChild(aEdit)

                            var iEdit = document.createElement("i");
                            iEdit.textContent = "create";
                            iEdit.setAttribute("class", "material-icons");
                            aEdit.appendChild(iEdit);

                            td = document.createElement("td");
                            td.setAttribute("style", "text-align: center;");
                            tr.appendChild(td);

                            var aDel = document.createElement("a");
                            aDel.setAttribute("style", "cursor: pointer");
                            aDel.setAttribute("data-idClient", rez.Id);
                            aDel.setAttribute("onclick", "DeleteClient(this)");
                            td.appendChild(aDel)
                            var iDel = document.createElement("i");
                            iDel.textContent = "delete";
                            iDel.setAttribute("class", "material-icons");
                            aDel.appendChild(iDel);


                        }
                    }
                }
            },
            error: function (jqXHR, exception) {
                console.log("eroare");

                // ajaxError(jqXHR, exception);
            }
        });
        }

        function DeleteClient(thing) {
            var idClient = thing.getAttribute("data-idClient");
            var paramData = {
                data: idClient,
            };
            console.log(paramData.valueOf(0));
            $.ajax({
                type: "POST",
                url: "Clienti.aspx/DeleteClient",
                data: JSON.stringify(paramData.valueOf(0)),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                cache: false,
                success: function (response) {
                    var rv = response.d;

                    if (rv) {
                        loadClienti();
                    } else {

                    }
                },
                error: function (jqXHR, exception) {
                    console.log("eroare");
                }
            });

        }

        function OpenFormClient(thing) {
            var idClient = thing.getAttribute("data-idClient");

            var txtNume = document.getElementById("txtNume");
            var txtPrenume = document.getElementById("txtPrenume");
            var txtMail = document.getElementById("txtMail");
            var txtTelefon = document.getElementById("txtTelefon");
            var hIdClient = document.getElementById("hIdClient");

            txtNume.value = "";
            txtPrenume.value = "";
            txtMail.value = "";
            txtTelefon.value = "";
            hIdClient.value = idClient;
            console.log(idClient)

            var paramData = {
                data: idClient
            };

            $.ajax({
                type: "POST",
                url: "Clienti.aspx/GetClient",
                data: JSON.stringify(paramData.valueOf(0)),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                cache: false,
                success: function (response) {
                    var rv = response.d;
                    var rez = rv.data;
                    if (rv) {
                        txtNume.value = rez.Nume;
                        txtPrenume.value = rez.Prenume;
                        txtMail.value = rez.Mail;
                        txtTelefon.value = rez.Telefon;
                        $('#modal-form-client').modal('show');


                    } else {
                        console.log("eroare");
                    }
                },
                error: function (jqXHR, exception) {
                    //console.log("eroare");
                }
            });

        }

        function SaveClient() {

            var txtNume = document.getElementById("txtNume");
            var txtPrenume = document.getElementById("txtPrenume");
            var txtMail = document.getElementById("txtMail");
            var txtTelefon = document.getElementById("txtTelefon");
            var idClient = document.getElementById("hIdClient");


            var paramData = {
                Id: idClient.value,
                Nume: txtNume.value,
                Prenume: txtPrenume.value,
                Mail: txtMail.value,
                Telefon: txtTelefon.value,
            };
            console.log(paramData)
            $.ajax({
                type: "POST",
                url: "Clienti.aspx/ClientAM",
                data: JSON.stringify(paramData.valueOf(0)),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                cache: false,
                success: function (response) {
                    var rv = response.d;

                    if (rv) {
                        $('#modal-form-client').modal('hide');
                        loadClienti();
                    } else {
                        console.log("Eroare");
                    }
                    ;
                },
                error: function (jqXHR, exception) {
                    console.log("Eroare");
                }
            });

        }

        function adaugaClient() {

            var txtNume = document.getElementById("txtNume");
            var txtPrenume = document.getElementById("txtPrenume");
            var txtMail = document.getElementById("txtMail");
            var txtTelefon = document.getElementById("txtTelefon");
            var hIdClient = document.getElementById("hIdClient");

            txtNume.value = "";
            txtPrenume.value = "";
            txtMail.value = "";
            txtTelefon.value = "";
            hIdClient.value = "0";
            $('#modal-form-client').modal('show');

        }



    </script>


</asp:Content>
