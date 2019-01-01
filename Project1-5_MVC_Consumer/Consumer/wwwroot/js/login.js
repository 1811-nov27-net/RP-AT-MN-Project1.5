$( '#loginForm' ).submit( function ( event )
{
	event.preventDefault();

	let role = $( this ).find( ':selected' ).data( 'role' );
	sessionStorage.setItem( "role", role );
} );

//browser work to hide elements js worked jquery had issues
//let x = document.getElementById( 'navHome' );
//undefined
//x
//	< li id = "navHome" class="nav-item" >
//		x.hidden;
//false
//x.hidden = true;
//true
//x.hide = false;
//false
//x.hidden = false;
//false
//$( 'navHome' ).hide();