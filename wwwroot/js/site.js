// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function locationEnter(event)
{
    if (event.keyCode == 13)
    {
        let input = document.getElementById("location-input").value;

        const xhttp = new XMLHttpRequest();
        xhttp.onload = function()
        {
            input = this.responseText;
        }

        const url = "geo/" + input;
        xhttp.open("GET", url, true);
        xhttp.send();

        document.getElementById("location-input").value = null;
        window.location.replace("/Home/forecast");
    }
}

function sidebarButton()
{
    if (isOpen)
    {
        document.getElementById("sidebar-close-button").innerHTML = "&#9776;";
        document.getElementById("left-side").style.width = "35px";
        document.getElementById("searchbar").style.visibility = "Hidden";
        isOpen = false;
    }
    else
    {
        document.getElementById("sidebar-close-button").innerHTML = "Close &times;";
        document.getElementById("left-side").style.width = "300px";
        document.getElementById("searchbar").style.visibility = "Visible";
        isOpen = true;
    }
}