// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var danish = document.getElementById('dk_click'),
    english = document.getElementById('en_click'),
    dk_txt = document.querySelectorAll('#dk'),
    en_txt = document.querySelectorAll('#en'),
    nb_dk = dk_txt.length,
    nb_en = en_txt.length;

danish.addEventListener('click', function() {
    langue(danish,english);
}, false);

english.addEventListener('click', function() {
    langue(english,danish);
}, false);

function langue(langueOn,langueOff){
    if (!langueOn.classList.contains('current_lang')) {
        langueOn.classList.toggle('current_lang');
        langueOff.classList.toggle('current_lang');
    }
    if(langueOn.innerHTML == 'Dk'){
        afficher(dk_txt, nb_dk);
        cacher(en_txt, nb_en);
    }
    else if(langueOn.innerHTML == 'En'){
        afficher(en_txt, nb_en);
        cacher(dk_txt, nb_dk);
    }
}

function afficher(txt,nb){
    for(var i=0; i < nb; i++){
        txt[i].style.display = 'block';
    }
}
function cacher(txt,nb){
    for(var i=0; i < nb; i++){
        txt[i].style.display = 'none';
    }
}
function init(){
    langue(danish,english);
}
init();