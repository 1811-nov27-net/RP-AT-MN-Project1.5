$( '#loginForm' ).submit( function ( event )
{
	event.preventDefault();
    
    let role = $(this).find(':selected').data('role');

    sessionStorage.setItem("role", role);
    sessionStorage.setItem("authenticated", true);

    window.location.replace("/");
} );
