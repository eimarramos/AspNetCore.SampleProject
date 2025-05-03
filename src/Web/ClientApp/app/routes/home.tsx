import { HomeComponent } from "~/pages/Home/Home";
import type { Route } from "./+types/home";

export function meta({}: Route.MetaArgs) {
  return [
    { title: "Pokedex" },
    { name: "Pokedex", content: "Welkome to Pokedex" },
  ];
}

export default function Home() {
  return <HomeComponent />;
}
