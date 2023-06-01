import React from "react";

interface VacanciesProps {
  vacancies: Array<any>;
}

const Vacancies: React.FC<VacanciesProps> = ({ vacancies }) => {
  return (
    <div>
      {vacancies.map(() => (
        <div></div>
      ))}
    </div>
  );
};

export default Vacancies;
