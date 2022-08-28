pub enum Suit {
  Club,
  Diamond,
  Heart,
  Spade,
}

impl Suit {
  pub fn from(value: &str) -> Result<Suit, ()> {
    let c = value.chars().last().unwrap_or('_');
    match c {
      'C' => Ok(Suit::Club),
      'D' => Ok(Suit::Diamond),
      'H' => Ok(Suit::Heart),
      'S' => Ok(Suit::Spade),
      _ => Err(()),
    }
  }
}

pub enum Value {
  Ace,
  King,
  Queen,
  Jack,
  Number(i32),
}

impl Value {
  pub fn from(value: &str) -> Result<Value, ()> {
    let mut chars = value.chars();
    chars.next_back();
    let str = String::from_iter(chars);
    match str.parse::<i32>() {
      Ok(int) => Ok(Value::Number(int)),
      _ => match str.as_str() {
        "A" => Ok(Value::Ace),
        "K" => Ok(Value::King),
        "Q" => Ok(Value::Queen),
        "J" => Ok(Value::Jack),
        _ => Err(()),
      },
    }
  }
}

impl Into<i32> for Value {
  fn into(self) -> i32 {
    match self {
      Value::Ace => 14,
      Value::King => 13,
      Value::Queen => 12,
      Value::Jack => 11,
      Value::Number(n) => n,
    }
  }
}

pub struct Card {
  pub suit: Suit,
  pub value: Value,
}

impl Card {
  pub fn from(str: &str) -> Card {
    Card {
      suit: Suit::from(str).unwrap(),
      value: Value::from(str).unwrap(),
    }
  }
}

pub struct Hand {
  cards: Vec<Card>,
}

impl Hand {
  pub fn from(cards: &str) -> Hand {
    let cards = cards.split_whitespace().map(Card::from).collect();
    Hand { cards: cards }
  }
}
