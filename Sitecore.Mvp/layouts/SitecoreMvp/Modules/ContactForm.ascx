<%@ Control Language="C#" AutoEventWireup="true" Inherits="Sitecore.Mvp.Core.Views.Modules.ContactFormView" %>


<div class="container">

    <div class="well form-horizontal">
        <fieldset>

            <!-- Form Name -->
            <legend><%= Editable(x => x.Title) %></legend>

            <!-- Text input-->

            <div class="form-group">
                <label class="col-md-4 control-label"><%= Editable(x => x.Name) %></label>
                <div class="col-md-4 inputGroupContainer">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                        <input name="name" placeholder="" class="form-control" type="text">
                    </div>
                </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
                <label class="col-md-4 control-label"><%= Editable(x => x.Email) %></label>
                <div class="col-md-4 inputGroupContainer">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                        <input name="email" placeholder="" class="form-control" type="text">
                    </div>
                </div>
            </div>
            
            <!-- Success message -->
            <div class="alert alert-warning" role="alert" id="SuccessMessage" runat="server" Visible="False">
                <%= Model.ErrorMessage %>
            </div>

            <!-- Button -->
            <div class="form-group">
                <label class="col-md-4 control-label"></label>
                <div class="col-md-4">
                    <button type="submit" runat="server" OnServerClick="BtnSubmitClick" class="btn btn-warning"><%= Model.Submit.Text %> <span class="glyphicon glyphicon-send"></span></button>
                </div>
            </div>

        </fieldset>
    </div>
</div>
</div><!-- /.container -->