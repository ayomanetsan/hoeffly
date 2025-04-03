import { definePreset } from '@primeng/themes';
import Aura from '@primeng/themes/aura';

export const Hoeffly = definePreset(Aura, {
  primitive: {
    borderRadius: {
      none: '0',
      md: '10px',
    },
  },

  semantic: {
    primary: {
      50: '#FDEDF1FF',
      100: '#FBDAE2FF',
      200: '#F7B6C6FF',
      300: '#F395ADFF',
      400: '#EF7190FF',
      500: '#DD3E68FF',
      600: '#E1194BFF',
      700: '#AA1339FF',
      800: '#6E0C25FF',
      900: '#370612FF',
      950: '#1C0309FF',
    },
    formField: {
      paddingX: '1rem',
      paddingY: '0.5rem',
    },
  },
});
