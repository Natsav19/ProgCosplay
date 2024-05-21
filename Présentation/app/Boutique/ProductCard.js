import { FaTrash, FaEdit } from 'react-icons/fa';
import React from 'react';

export default function ProductCard(props){
    return (
        <div className="col-lg-4 col-md-6 mb-4">
            <div className="card m-2 custom-card">
            <div className="ratio ratio-16x9"> 
                    <img src={props.image} className="card-img-top m-2" alt="Image 1"/>
                </div>
                <div className="card-body">
                    <h5 className="card-title fw-bold">{props.titre}</h5>
                    <p className="card-text m-3 text-truncate-2">{props.Contenu}</p>
                    <h4 className='fw-bold '> Prix : {props.prix}$</h4>
                    <h6> Il reste {props.nbInventaire} articles.</h6>
                    <div className="d-flex justify-content-between">
                        <a href={`Produits/${props.cosplayID}`} className="btn btn-primary">Lire la suite</a>
                        <div>
                            <button className="btn btn-secondary me-2">
                                <a className='text-decoration-none text-white' href={`../ModifProduit/${props.cosplayID}`}>
                                    <FaEdit /> Modifier
                                </a>
                            </button>
                            <button className="btn btn-danger text-decoration-none">
                                <a className='text-decoration-none text-white' href={`../SuppProduit/${props.cosplayID}`}>
                                    <FaTrash /> Supprimer
                                </a>
                            </button>
                        </div>
                    </div>
                </div>
            </div> 
        </div>
    )
}
