import styled from 'styled-components';
import { ThemeType } from '../../assets/theme';

interface TitleProps {
  theme: ThemeType
}

export const Title = styled.h1<TitleProps>`
  font-size: ${({ theme }) => theme.fontSize.xl};
  color: ${({ theme }) => theme.colors.darkGrey};
`;