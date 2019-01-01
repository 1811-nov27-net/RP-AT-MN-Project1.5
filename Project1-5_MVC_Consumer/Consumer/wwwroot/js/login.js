$( '#loginForm' ).submit( function ( event )
{
	event.preventDefault();

	let role = $( this ).find( ':selected' ).data( 'role' );
	alert( role );
} );