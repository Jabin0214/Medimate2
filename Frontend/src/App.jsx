import React from "react";
import { Link } from "react-router-dom";

const App = () => {
  const cards = [
    { id: 1, title: "MediSearch", description: "Search for medications", link: "/search" },
    { id: 2, title: "MediLogin", description: "Login to your account", link: "/login" },
    { id: 3, title: "MediChat", description: "Chat with experts", link: "/chat" },
  ];

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center justify-center">
      <h1 className="text-2xl font-bold mb-6 text-gray-800">Medimate Web</h1>
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6 px-4 max-w-4xl">
        {cards.map((card) => (
          <Link
            key={card.id}
            to={card.link}
            className="bg-white shadow-lg rounded-lg p-6 hover:shadow-xl transition-shadow"
          >
            <h2 className="text-xl font-semibold text-gray-700 mb-4">{card.title}</h2>
            <p className="text-gray-600">{card.description}</p>
          </Link>
        ))}
      </div>
    </div>
  );
};

export default App;