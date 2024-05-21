"use client";
import React, { useEffect, useState } from 'react';
import StyleForm from '../../AjoutProduit/Form.css';

export default function ModifyForm(props) {
    const [produit, setproduit] = useState(null);

    useEffect(() => {
        async function fetchData() {
            const response = await fetch(`https://projet07-dicjprog4.cegepjonquiere.ca/api/Cosplays/${props.params.id}`, {
                method: 'GET',
                headers: {
                  'Content-Type': 'application/json',
                },
              });
            const data = await response.json();
            setproduit(data);
        }
        fetchData();
    }, [props.params.id]);

    if (!produit) {
        return <div>Chargement...</div>; 
    }
    async function confirmerModif(formData) {
        let titre = formData.get("titre");
        let contenu = formData.get("contenu");
        let prix = formData.get("prix");
        let nbInventaire = formData.get("nbInventaire");
        let image = formData.get("image");
        let token = localStorage.getItem('token');
        let username = localStorage.getItem('username');
        
        var nouveauProduit = {
            "cosplayId": props.params.id,
            "titre": titre,
            "contenu": contenu,
            "prix": prix,
            "nbInventaire": nbInventaire,
            "image": image,
            "quantite": 1,
            "proprietaireId": username,       
            };   
        console.log(localStorage.getItem('token'));
        await fetch("https://projet07-dicjprog4.cegepjonquiere.ca/api/Cosplays/" + props.params.id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + localStorage.getItem('token')
            },
            body: JSON.stringify(nouveauProduit),
            })


    }
    return( 
        <>
        <div className="d-flex flex-column justify-content-center align-items-center m-5">
        <form id="ModifyProduit" className="d-flex flex-column justify-content-center align-items-center" action={confirmerModif}>
            <div className="mb-3 w-75">
                <label htmlFor="titre" className="form-label text-white">Titre:</label>
                <input type="text" id="titre" className="form-control" name="titre"  value={produit.titre} onChange={(e) => setproduit({ ...produit, titre: e.target.value }) }required/>
            </div>
            <div className="mb-3 w-75">
                <label htmlFor="contenu" className="form-label text-white">Contenu:</label>
                <textarea className="form-control" id="contenu" name="contenu" rows="4" cols="50"  value={produit.contenu} onChange={(e) => setproduit({ ...produit, contenu: e.target.value }) }required></textarea>
            </div>
            <div className="mb-3 w-75">
                <label htmlFor="prix" className="form-label text-white">Prix:</label>
                <input type="double" className="form-control" id="prix" name="prix"  value={produit.prix} onChange={(e) => setproduit({ ...produit, prix: e.target.value }) }required/>
            </div>
            <div className="mb-3 w-75">
                <label htmlFor="nbInventaire" className="form-label text-white">Nombre en inventaire:</label>
                <input type="number" className="form-control" id="nbInventaire" name="nbInventaire"  value={produit.nbInventaire} onChange={(e) => setproduit({ ...produit, nbInventaire: e.target.value }) }required/>
            </div>
            <div className="mb-3 w-75">
                <label htmlFor="image" className="form-label text-white">Image:</label>
                <input type="text" id="image" name="image"  value={produit.image} onChange={(e) => setproduit({ ...produit, Image: e.target.value }) } required/>
            </div>
            <div className="mb-3">
                <button type="submit" id="send" className="btn btn-primary">Envoyer</button>
            </div>
        </form>
    </div>
        </>
    );
}

