

function disableButton(btn) {    
    btn.classList.add("disabled");
}

function modalDuplicate(planId, planName) {
    event.preventDefault();

    elementSet('duplicatePLanId', planId);    
    $('#duplicatePlan').modal('show').fadeIn("slow");
}

function showModal(planId, planName) {
    event.preventDefault();

    elementSet('deletePLanId', planId);   

    elementInner('planName', planName);

    $('#deleteRecord').modal('show').fadeIn("slow");
}

function deleteFilter(propertyName) {
    document.getElementById(propertyName).value = "";
    document.getElementById("search").submit();
}
function elementGet(property) {
    return document.getElementById(property).value;
}

function elementInner(element, toInner) {
    document.getElementById(element).innerHTML = toInner;
}

function elementGetInner(element) {
    return document.getElementById(element).innerHTML;
}

function elementSet(property, value) {
    document.getElementById(property).value = value;
}



function showMsg(msg) {

    
    elementInner("confirmModalMsg", msg);

    $("#confirmModal").modal('show');

    setTimeout(function () {
        $("#confirmModal").modal('hide');
    }, 3000);
}

function modifiTotal(moreOrLess) {

    var currentValue = elementGetInner('total');
    var newValue = moreOrLess === "up" ? parseInt(currentValue) + 1 : parseInt(currentValue) - 1;
    elementInner("total", newValue);


}
$(document).ready(function () {
    comprobarCookiesAdmin();
});



jQuery(document).ready(function ($) {


    /*Focus window*/
    var debouncedFocus = _.debounce(() => {


        comprobarCookiesAdmin();



    }, 250, { leading: true, trailing: false });

    $(window).on('focus', debouncedFocus);

    /*MODO ADMISITRADOR*/
    $('body').on('change', '.togglebutton.admin', function (e) {

        var url = window.location.pathname.split("/").pop()

        if ($(this).find('input').is(':checked') == true) {
            document.cookie = "administrador=1;";
            setTimeout(function () {
                $('.togglebutton.admin input').prop("checked", true);
                $('.dropdown-item.listadoUsuarios').show();
                $('.main-panel .navbar').addClass('administrador');
            }, 100);

            if ((url.indexOf("index") >= 0) || (url == '')) {

                var data = $.get("include_dashboard_admin.html")
                $.get("include_dashboard_admin.html", function (data) {
                    $('.main-panel').html(data);
                });
                $('.dropdown-item.listadoUsuarios').show();

            }
            if ((url.indexOf("listado_presupuesto") >= 0) || (url.indexOf("listado_certificados") >= 0) || (url.indexOf("listado_cotizaciones") >= 0) || (url.indexOf("listado_contrataciones") >= 0) || (url.indexOf("listado_suplementos") >= 0) || (url.indexOf("listado_siniestros") >= 0)) {

                $('.table-responsive .admin').show();
                $('.table-responsive').attr('colspan', 17);
                $('.table-responsive .table-row').attr('colspan', 17);
                $('.table-responsive .table-row td.p-0').attr('colspan', 17);
                $('.table-responsive .table-row tr.collapse').attr('colspan', 17);

            }



        } else {


            document.cookie = "administrador=0;";
            document.cookie = "nombreusuario=";

            setTimeout(function () {
                $('.togglebutton.admin input').prop("checked", false);
                $('.dropdown-item.listadoUsuarios').hide();
                $('.main-panel .navbar').removeClass('administrador');
            }, 100);

            $('.togglebutton.admin label .usuarioNombre').html('');

            if ((url.indexOf("index") >= 0) || (url == '')) {


                var data = $.get("include_dashboard.html")
                $.get("include_dashboard.html", function (data) {
                    $('.main-panel').html(data);
                });
                $('.dropdown-item.listadoUsuarios').hide();

            }
            if ((url.indexOf("listado_presupuesto") >= 0) || (url.indexOf("listado_certificados") >= 0) || (url.indexOf("listado_cotizaciones") >= 0) || (url.indexOf("listado_contrataciones") >= 0) || (url.indexOf("listado_suplementos") >= 0) || (url.indexOf("listado_siniestros") >= 0)) {
                $('.table-responsive .admin').hide();
                $('.table-responsive').attr('colspan', 16);
                $('.table-responsive .table-row').attr('colspan', 16);
                $('.table-responsive .table-row td.p-0').attr('colspan', 16);
                $('.table-responsive .table-row tr.collapse').attr('colspan', 16);

            }


        }

    });

    $('body').on('click', '.enviarUsuario', function (e) {

        var url = window.location.pathname.split("/").pop()

        var nombreUsuario = $('input[name=usuarios]:checked').val();
        if (nombreUsuario != null) {
            document.cookie = "nombreusuario=(" + nombreUsuario + ");";


            if ((url.indexOf("index") >= 0) || (url == "")) {

                var data = $.get("include_dashboard.html")
                $.get("include_dashboard.html", function (data) {
                    $('.main-panel').html(data);
                });

            }
            if ((url.indexOf("listado_presupuesto") >= 0) || (url.indexOf("listado_certificados") >= 0) || (url.indexOf("listado_cotizaciones") >= 0) || (url.indexOf("listado_contrataciones") >= 0) || (url.indexOf("listado_suplementos") >= 0) || (url.indexOf("listado_siniestros") >= 0)) {

                $('.table-responsive .admin').hide();
                $('.table-responsive').attr('colspan', 16);
                $('.table-responsive .table-row').attr('colspan', 16);
                $('.table-responsive .table-row td.p-0').attr('colspan', 16);
                $('.table-responsive .table-row tr.collapse').attr('colspan', 16);

            }
            setTimeout(function () {
                $('.togglebutton.admin label .usuarioNombre').html("(" + nombreUsuario + ")");
                $('.togglebutton.admin input').prop("checked", true);
                $('.main-panel .navbar').addClass('administrador');
            }, 100);


            if (nombreUsuario == 'todos') {
                document.cookie = "nombreusuario=;";

                if ((url.indexOf("index") >= 0) || (url == "")) {

                    var data = $.get("include_dashboard_admin.html")
                    $.get("include_dashboard_admin.html", function (data) {
                        $('.main-panel').html(data);
                    });
                }

                if ((url.indexOf("listado_presupuesto") >= 0) || (url.indexOf("listado_certificados") >= 0) || (url.indexOf("listado_cotizaciones") >= 0) || (url.indexOf("listado_contrataciones") >= 0) || (url.indexOf("listado_suplementos") >= 0) || (url.indexOf("listado_siniestros") >= 0)) {

                    $('.table-responsive .admin').show();
                    $('.table-responsive').attr('colspan', 17);
                    $('.table-responsive .table-row').attr('colspan', 17);
                    $('.table-responsive .table-row td.p-0').attr('colspan', 17);
                    $('.table-responsive .table-row tr.collapse').attr('colspan', 17);

                }

                setTimeout(function () {
                    $('.togglebutton.admin label .usuarioNombre').html("");
                    $('.togglebutton.admin input').prop("checked", true);
                    $('.main-panel .navbar').addClass('administrador');
                }, 100);

            }
        }

    });

    /*Imprimir pantalla*/
    $('body').on('click', '.imprimir', function (e) {
        window.print();
        return false;
    });


    $('.filenames').on('click', '.remove', function () {
        $(this.parentElement).remove();
    });
    


    $().ready(function () {
        $sidebar = $('.sidebar');

        $sidebar_img_container = $sidebar.find('.sidebar-background');

        $full_page = $('.full-page');

        $sidebar_responsive = $('body > .navbar-collapse');

        window_width = $(window).width();

        fixed_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();

        if (window_width > 767 && fixed_plugin_open == 'Dashboard') {
            if ($('.fixed-plugin .dropdown').hasClass('show-dropdown')) {
                $('.fixed-plugin .dropdown').addClass('open');
            }

        }
    });
});

$(document).ready(function () {

    (function ($) {

        $('#filtrar').keyup(function () {

            var rex = new RegExp($(this).val(), 'i');


            $('#list1 .panel-title').hide();
            $('#list1 .panel .list-group .list-group-item').hide();
            $('#list1 .panel-title').filter(function () {

                return rex.test($(this).text());
            }).show();


        })

    }(jQuery));
});

$(document).ready(function () {

    (function ($) {

        $('#filtrar2').keyup(function () {

            if ($(this).val() == "") {
                $('#list2 .panel-collapse').removeClass('show');
            } else {
                if (!$('#list2 .panel-collapse').hasClass("show")) {
                    $('#list2 .panel-collapse').addClass('show');
                }
            }


            var rex = new RegExp($(this).val(), 'i');

            $('#list2 .panel-title').hide();
            $('#list2 .panel-title').filter(function () {
                return rex.test($(this).text());
            }).show();
            $('#list2 .panel .list-group .list-group-item').hide();
            $('#list2 .panel .list-group .list-group-item').filter(function () {
                //alert($(this).parent().parent().parent('.panel-heading panel-title').get( 0 ).text());
                return rex.test($(this).text());
            }).show();

        })

    }(jQuery));


    $('body').on('click', '.fullPage', function (e) {

        e.preventDefault();
        openFullscreen();

    });
    $(".dropdown-menu .inner ul").on('wheel', function (event) {
        console.log("wheel");
        $(".card-body").perfectScrollbar('destroy');

    })

    $('.bootstrap-select').on('show.bs.dropdown', function () {
        var dropDownHeight = $(this).find($('.dropdown-menu')).outerHeight();
        var wrapperHeight = $('.card-body').outerHeight();
        var newHeight = wrapperHeight - ($(this).offset().top);

        if (dropDownHeight > (wrapperHeight / 2)) {
            // $(this).find($('div.dropdown-menu')).addClass('customDropdown');

            $(this).find($('div.dropdown-menu')).css('height', newHeight);
            $(this).find($('div.dropdown-menu')).css('max-height', newHeight);
            $(this).find($('div.dropdown-menu')).css('min-height', newHeight);
            $(this).find($('div.dropdown-menu .inner')).css('max-height', newHeight);

            if ($(this).find($('div.dropdown-menu .inner')).prev().hasClass('bs-searchbox')) {

                $(this).find($('div.dropdown-menu .inner')).css('max-height', (newHeight - 48));
            }



        }
    })

    $('input[name="chkOrgRow"]').on('change', function () {
        $(this).closest('tr').toggleClass('trlorange', $(this).is(':checked'));
    });

    $('body').tooltip({ selector: '[data-toggle="tooltip"]' });
    /*GOTO SPECIFIC TAB*/

    var url = document.location.toString();

    if (url.match('#')) {

        $('.nav-tabs a[href="#' + url.split('#')[1] + '-tab"]').tab('show');
    } //add a suffix

    // Change hash for page-reload
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        console.log("tab shown...");
    });

    // read hash from page load and change tab
    var hash = document.location.hash;
    var prefix = "tab_";
    if (hash) {
        $('.nav-tabs a[href="' + hash.replace(prefix, "") + '"]').tab('show');
    }




    //init DateTimePickers
    md.initFormExtendedDatetimepickers();
    if ($("#moneda").val() != null) {
        comprobarEuro($("#moneda").val());
    }

    $("#moneda").change(function () {
        comprobarEuro($("#moneda").val());
    });

    $('.card-body').on('wheel', function (event) {

       
          
            $(".dropdown-menu .inner ul").on('wheel', function (event) {
                $(".card-body").perfectScrollbar('destroy');

            })
        
        $(".card-body").perfectScrollbar();

    });

    /*Alternativa buscador relativo*/

    $('body').on('click', '.buscadorRelativo .search', function (e) {
        $('.buscadorRelativoContent').show(500);
        $('.buscadorRelativoContent .btn .cerrarBuscador').show();
        $('.buscadorRelativo').hide();
        $('.tags').hide(500);
        $('.main-panel').scrollTop(0);
    })

    $('body').on('click', '.buscadorRelativoContent .cerrarBuscador', function (e) {
        e.preventDefault();

        $('.buscadorRelativoContent').hide(500);
        $('.buscadorRelativoContent .cerrarBuscador').hide();
        $('.buscadorRelativo').show();
        $('.tags').show(500);
    })

    /*Dropdown como Select con input*/
    $('body').on('click', '.dropdown-menu.form ul li', function (e) {
        var selText = $(this).text();
        $(this).parents('.btn-group').find('.dropdown-toggle').html(selText + ' <span class="caret"></span>');
    });

    $('body').on('click', '.dropDownForm', function (e) {
        //e.stopPropagation();
        e.preventDefault();
        var identificador = $(this).parent().parent().attr('id');

        var nuevoTermino = $(this).prev().val();

        if (nuevoTermino != '') {
            $("#" + identificador + " .dropdown-menu.form ul").append('<li class="dropdown-item">' + nuevoTermino + '<div class="ripple-container"></div></li>');
            $("#" + identificador + " .dropdown-menu.form input.nuevoCampo").val('');
            $("#" + identificador + ".btn-group.form a").text(nuevoTermino);
        }
    });

   

    /*Buscador en el Dropdown*/
    $('body').on('keyup', '.buscador', function (e) {
        _this = this;
        var identificador = $(this).parent().parent().attr('id');

        $.each($(".dropdown-menu.form ul li"), function () {
            if ($(this).text().toLowerCase().indexOf($(_this).val().toLowerCase()) === -1)
                $(this).hide();
            else
                $(this).show();
        });
    });

    // If the document is clicked somewhere
    $(document).bind("mousedown", function (e) {

        // If the clicked element is not the menu
        if (!$(e.target).parents(".custom-menu").length > 0) {

            // Hide it
            $(".custom-menu").hide(100);
        }
    });


    // If the menu element is clicked
    $(".custom-menu li").click(function () {

        // This is the triggered action name
        switch ($(this).attr("data-action")) {

            // A case for each action. Your actions here
            case "abrir": var url = $(this).data('href'); window.open(url); break;
            /* case "second": alert("second"); break;
             case "third": alert("third"); break;*/
        }

        // Hide it AFTER the action was triggered
        $(".custom-menu").hide(100);
    });

    $.bootstrapSortable(true);



    w3IncludeHTML();

});



function comprobarEuro(moneda) {
    if (moneda == "euro") {
        $(".cambioEuros").hide(500);
    } else {
        $(".cambioEuros").show(500);

    }
}
function openFullscreen() {


    var elem = document.documentElement;

    if (elem.requestFullscreen) {
        elem.requestFullscreen();
    } else if (elem.mozRequestFullScreen) { /* Firefox */
        elem.mozRequestFullScreen();
    } else if (elem.webkitRequestFullscreen) { /* Chrome, Safari and Opera */
        elem.webkitRequestFullscreen();
    } else if (elem.msRequestFullscreen) { /* IE/Edge */
        elem.msRequestFullscreen();
    }
}
function lookup(arg) {
    var id = arg.getAttribute('id');
    var characterCount = $(arg).val().length,
        current = $('.' + id + ' .current'),
        maximum = $('.' + id + ' .maximum'),
        theCount = $('.' + id + ' .the-count');


    current.text(characterCount);

}

function newTab() {
    $(this).tab('show');

}
function readCookie(name) {

    var nameEQ = name + "=";
    var ca = document.cookie.split(';');

    for (var i = 0; i < ca.length; i++) {

        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) {
            return decodeURIComponent(c.substring(nameEQ.length, c.length));
        }

    }

    return null;

}

/*MODO ADMISITRADOR COOKIES*/
function comprobarCookiesAdmin() {
    var administrador = readCookie("administrador");
    var cookieAdmin = readCookie("administrador");
    var nombreUsuario = readCookie("nombreusuario");

    if (cookieAdmin == 1) {

        setTimeout(function () {
            $('.dropdown-item.listadoUsuarios').show();
            $('.main-panel .navbar').addClass('administrador');
            $('.togglebutton.admin input').prop("checked", true);
        }, 200);


        if (nombreUsuario != null) {
            setTimeout(function () {
                $('.togglebutton.admin label .usuarioNombre').html(nombreUsuario);
            }, 100);
        }


    } else {

        setTimeout(function () {
            $('.dropdown-item.listadoUsuarios').hide();
            $('.main-panel .navbar').removeClass('administrador');
            $('.togglebutton.admin input').prop("checked", false);
            $('.togglebutton.admin label .usuarioNombre').html('');

        }, 200);

    }
}
/*Validación formularios*/
function setFormValidation(id) {
    $(id).validate({
        highlight: function (element) {
            $(element).closest('.form-group').removeClass('has-success').addClass('has-danger');
            $(element).closest('.form-check').removeClass('has-success').addClass('has-danger');
        },
        success: function (element) {
            $(element).closest('.form-group').removeClass('has-danger').addClass('has-success');
            $(element).closest('.form-check').removeClass('has-danger').addClass('has-success');
        },
        errorPlacement: function (error, element) {
            $(element).closest('.form-group').append(error);
        }
    });
}


