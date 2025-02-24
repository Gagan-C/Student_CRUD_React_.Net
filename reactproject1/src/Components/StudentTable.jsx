import React from 'react';

function StudentTable({ students, onDelete }) {
  const handleDelete = async (studentId) => {
    try {
      const response = await fetch(`http://localhost:5096/api/student/${studentId}`, {
        method: 'DELETE',
      });
      if (response.ok) {
        onDelete(studentId);
      } else {
        console.error('Failed to delete student');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Address</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {students.map((student, index) => (
            <tr key={index}>
              <td>{student.firstName}</td>
              <td>{student.lastName}</td>
              <td>{student.address}</td>
              <td>
                <button onClick={() => handleDelete(student.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default StudentTable;