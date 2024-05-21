"use client";
import { useState, useEffect } from 'react';
import Link from 'next/link';

export default function Header() {
    const [showSearch, setShowSearch] = useState(false);
    const [searchOpened, setSearchOpened] = useState(false);

    const handleImageClick = () => {
        console.log("Image clicked");
        setShowSearch(!showSearch);
        setSearchOpened(!searchOpened);
        console.log("showSearch:", showSearch);
        console.log("searchOpened:", searchOpened);
    };

    return (
        <>
            <nav className="navbar navbar-expand-lg">
                <div className="container">
                    <a className="navbar-brand fs-4" href="/">
                        <img src="/image/CosplayZone.png" alt="Bootstrap" width="50%" height="50%" />
                    </a>
                    <button className="navbar-toggler shadow-none border-0" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="sidebar offcanvas offcanvas-end" tabIndex="-1" id="offcanvasNavbar" aria-labelledby="offcanvasNavbarLabel">
                        <div className="offcanvas-header text-white border-bottom">
                            <h5 className="offcanvas-title" id="offcanvasNavbarLabel">Cosplay-Zone</h5>
                            <button type="button" className="btn-close btn-close-white shadow-none" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div className="offcanvas-body">
                            <ul className="navbar-nav justify-content-center align-items-center fs-3 flex-grow-1 pe-3 text-decoration-none ">
                                <li className="nav-item mx-2">
                                    <Link className="text-decoration-none text-black" href="/">Accueil</Link>
                                </li>
                                <li className="nav-item mx-2">
                                    <Link className="text-decoration-none text-black" href="/Boutique">Boutique</Link>
                                </li>
                                <li className="nav-item mx-2">
                                    <a className="nav-a text-decoration-none text-black" href="index.html">Aide</a>
                                </li>
                                <li className="nav-item mx-2">
                                    <a className="nav-a text-decoration-none text-black" href="#">Contact</a>
                                </li>
                            </ul>
                            <div className="d-flex justify-content-end align-items-end">
                                <button className="text-white" onClick={handleImageClick} style={{ border: 'none', background: 'none', padding: 0, cursor: 'pointer' }}>
                                    <img src="/image/detective_conan.png" alt="Bootstrap" width="50%" height="50%" />
                                </button>
                                <a className="text-white" href="../Panier">
                                    <img src="/image/PanierShop.png" alt="Bootstrap" width="60%" height="60%" />
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </nav>
            {searchOpened && (
                <div className="search">
                    <div className="row d-flex justify-content-space-between justify-content-center">
                        <div className="col-lg-4">
                            <div className="p-3">
                                <form className="d-flex">
                                    <div className="input-group mb-3">
                                        <input type="text" className="form-control" placeholder="Rechercher" aria-label="Search" aria-describedby="button-addon" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </>
    );
}
