
 var tabbar         = $(".nav-tabs-wrapper");
 //$('ul#pestanas.principal li .dropdown.overflow .ocultos').html('');

var tabsToList = function() {
	//console.log('valor inicial '+value);
	var tabbarWidth  = tabbar.width();
	var tabListItem=$('ul#pestanas.principal').children();
	
	var tabListItemOffset=180;
	

	$('ul#pestanas.principal li .dropdown.overflow .ocultos').html('');
	tabListItem.each(function(index) {
		
		tabListItemOffset+= $(this).outerWidth();
		
		var listadoOverflow=$('ul#pestanas.principal li .dropdown.overflow');
		
		
		if (tabListItemOffset >= tabbarWidth) {
			console.log(tabListItemOffset+' '+tabbarWidth);
			
			if(!$(this).children().hasClass("dropdown")){
				
				$(this).removeClass("show");
				$(this).addClass("hide").find("li.nav-item");

				var itemIncluir=$(this).find("a");
				var itemIncluirTexto=itemIncluir.text();
				var itemIncluirEnlace=itemIncluir.attr('href');
		
				$('ul#pestanas.principal li .dropdown.overflow .ocultos').append('<a href="'+itemIncluirEnlace+'" class="dropdown-item">'+itemIncluirTexto+'</a>');


			}
			listadoOverflow.show();
			
			
           
        }else{
			$(this).removeClass("hide");
			$(this).addClass("show").find("li.nav-item");
			listadoOverflow.hide();
		}
		
        
    });
	
   
};

$(window).on("load resize", tabsToList);

/*Mostrar items ocultos dropdown*/
$('body').on('click','.dropdown.overflow a',function() {
	
	
	$('.tab-content.pestanas .tab-pane.contentPestanas.active').removeClass('active');
	$('#pestanas.principal li.nav-item a.active').removeClass('active');
	
	var ruta=$(this).attr('href');
	$(this).remove();
	
	var nombre=ruta.replace('#','');
	$('.nav-item a[href$='+nombre+']').parent().remove();
	
	$('#pestanas.principal > li:nth-child(2)').after('<li class="nav-item"><a class="nav-link active" href="'+ruta+'" data-toggle="tab">'+nombre+'<button class="btn cerrarPestana"><i class="fas fa-times"></i></button></a></li>');         
	$('.tab-content.pestanas').append('<div class="tab-pane contentPestanas active" id="'+ruta+'"><div class="main-panel">'+nombre+'</div></div>');
	
	
	tabsToList();

});
$('body').on('click','.nuevaPestana',function() {
	tabsToList();
});
