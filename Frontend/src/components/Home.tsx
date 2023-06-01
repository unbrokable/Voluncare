import React from "react";

interface HomeProps {}

const Home: React.FC<HomeProps> = () => {
  return (
    <div
      style={{
        zIndex: 2,
        maxWidth: 1600,
        display: "flex",
        flexDirection: "column",
        margin: "auto",
        padding: 60,
        borderRadius: 30,
      }}
    >
      <text
        style={{
          color: "#fff",
          fontSize: 34,
          fontWeight: 600,
          marginBottom: 20,
          textAlign: "center",
        }}
      >
        🤝 Join Our Volunteer Network and Make a Difference in Ukraine! 🇺🇦
      </text>
      <text
        style={{
          color: "#fff",
          fontSize: 26,
          fontWeight: 600,
          marginBottom: 10,
        }}
      >
        🌍 Humanitarian Assistance: Ukraine is currently facing a complex
        crisis, with many individuals and communities in dire need of
        humanitarian aid. As a volunteer, you can directly contribute to
        providing essential support such as food, shelter, medical aid, and
        education to those affected by the crisis.
      </text>
      <text
        style={{
          color: "#fff",
          fontSize: 26,
          fontWeight: 600,
          marginBottom: 10,
        }}
      >
        🤲 Empower Communities: By volunteering in Ukraine, you have the
        opportunity to empower local communities and help them rebuild their
        lives. Whether it's assisting with community development projects,
        providing educational support, or organizing recreational activities,
        your involvement can foster resilience, hope, and a sense of empowerment
        among the people.
      </text>
      <text
        style={{
          color: "#fff",
          fontSize: 26,
          fontWeight: 600,
          marginBottom: 10,
        }}
      >
        💡 Skill Sharing and Capacity Building: Your skills and expertise can
        play a vital role in helping Ukraine recover and thrive. Whether you
        have experience in healthcare, education, engineering, technology, or
        any other field, your knowledge can be shared to enhance local capacity
        and contribute to sustainable development.
      </text>
      <text
        style={{
          color: "#fff",
          fontSize: 26,
          fontWeight: 600,
          marginBottom: 10,
        }}
      >
        🌐 Cultural Exchange: Immerse yourself in the rich Ukrainian culture,
        history, and traditions. By volunteering in Ukraine, you will have the
        chance to interact with local communities, learn their stories, and
        build bridges of understanding and friendship between cultures.
      </text>
    </div>
  );
};

export default Home;
