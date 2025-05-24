import React, { useState } from 'react';

const HistorialTransaccion = () => {
  const [formData, setFormData] = useState({
    fechaInicio: '',
    fechaFin: '',
    tipoTransaccion: ''
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    // Handle form submission logic here
    console.log('Form submitted:', formData);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  return (
    <div className="container mx-auto p-4">
      <h2 className="text-2xl font-bold mb-4">Transaction History</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label className="block mb-2">Start Date:</label>
          <input
            type="date"
            name="fechaInicio"
            value={formData.fechaInicio}
            onChange={handleChange}
            className="border p-2 rounded"
          />
        </div>
        <div>
          <label className="block mb-2">End Date:</label>
          <input
            type="date"
            name="fechaFin"
            value={formData.fechaFin}
            onChange={handleChange}
            className="border p-2 rounded"
          />
        </div>
        <div>
          <label className="block mb-2">Transaction Type:</label>
          <select
            name="tipoTransaccion"
            value={formData.tipoTransaccion}
            onChange={handleChange}
            className="border p-2 rounded w-full"
          >
            <option value="">Select type</option>
            <option value="deposito">Deposit</option>
            <option value="retiro">Withdrawal</option>
            <option value="transferencia">Transfer</option>
          </select>
        </div>
        <button 
          type="submit"
          className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
        >
          Search Transactions
        </button>
      </form>
    </div>
  );
};

export default HistorialTransaccion;
